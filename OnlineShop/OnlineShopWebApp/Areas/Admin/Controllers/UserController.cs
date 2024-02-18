using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> usersManager;
        private readonly RoleManager<IdentityRole> rolesManager;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment appEnvironment;

        public UserController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            this.usersManager = usersManager;
            this.rolesManager = rolesManager;
            this.mapper = mapper;
            this.appEnvironment = appEnvironment;
        }

        public async Task<ActionResult> GetUsersAsync()
        {
            var users = await usersManager.Users.ToListAsync();
            return View(mapper.Map<List<UserViewModel>>(users));
        }

        public async Task<ActionResult> GetUserDetailsAsync(string userId)
        {
            var user = await usersManager.FindByIdAsync(userId);
            return View(mapper.Map<UserViewModel>(user));
        }

        public IActionResult ChangePassword(string userId)
        {
            var password = new ChangePassword()
            {
                UserId = userId,
            };
            return View(password);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePasswordAsync(ChangePassword newPassword)
        {
            var user = await usersManager.FindByIdAsync(newPassword.UserId);         
            var compareResult = usersManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, newPassword.Password);
                
            if (compareResult == PasswordVerificationResult.Success)
                ModelState.AddModelError(string.Empty, "Пароль не должен совпадать со старым");

            if (ModelState.IsValid)
            {
                if (user.Email == newPassword.Password || user.Name == newPassword.Password)
                    ModelState.AddModelError(string.Empty, "Пароль не должен совпадать с именем или логином");

                var passwordValidator = HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                var result = await passwordValidator.ValidateAsync(usersManager, user, newPassword.Password);

                if (result.Succeeded)
                {
                    user.PasswordHash = usersManager.PasswordHasher.HashPassword(user, newPassword.Password);
                    await usersManager.UpdateAsync(user);
                    return RedirectToAction("GetUsers");
                }       

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(newPassword);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(Register register)
        {
            if (register.Login == register.Name)
                ModelState.AddModelError(string.Empty, "Логин и имя не должны совпадать");

            if ((await usersManager.FindByEmailAsync(register.Login)) is not null)
                ModelState.AddModelError(string.Empty, "Пользователь с таким Email уже существует");

            if (ModelState.IsValid)
            {
                var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/users");

                var user = new User 
                { 
                    Email = register.Login, 
                    Name = register.Name, 
                    UserName = register.Login, 
                    PhoneNumber = register.PhoneNumber,
                    Image = register.UpPhoto is null ? "/images/users/NoAvatar12723.jpg" : ImageProvider.SaveImage(folderPath, register.UpPhoto)
                };

                var result = await usersManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    await usersManager.AddToRoleAsync(user, Constants.UserRoleName);
                    return RedirectToAction("GetUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(register);
        }
        
        public async Task<ActionResult> EditUserAsync(string userId)
        {
            var user = await usersManager.FindByIdAsync(userId);
            return View(mapper.Map<UserViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> EditUserAsync(UserViewModel editedUser)
        {
            if (editedUser.Login == editedUser.Name)
                ModelState.AddModelError(string.Empty, "Имя и логин не должны совпадать");

            if (ModelState.IsValid)
            {
                var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/users");
                editedUser.Image = editedUser.UpPhoto is null ? editedUser.Image : ImageProvider.SaveImage(folderPath, editedUser.UpPhoto);
                var user = await usersManager.FindByIdAsync(editedUser.Id);
                mapper.Map(editedUser, user);
                await usersManager.UpdateAsync(user);
                return RedirectToAction("GetUsers");
            }

            return View(editedUser);
        }

        public async Task<ActionResult> ChangeRoleAsync(string userId)
        {
            var user = await usersManager.FindByIdAsync(userId);
            var userRole = (await usersManager.GetRolesAsync(user)).FirstOrDefault();

            if (user is not null)
            {
                var changeVM = new ChangeRoleViewModel()
                {
                    UserId = userId,
                    Roles = await rolesManager.Roles.ToListAsync(),
                    UserRole = userRole
                };
                return View(changeVM);
            }
            return RedirectToAction("GetUsers");
        }

        [HttpPost]
        public async Task<ActionResult> ChangeRoleAsync(string roleId, string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await usersManager.FindByIdAsync(userId);
                var userRoles = await usersManager.GetRolesAsync(user);
                await usersManager.RemoveFromRolesAsync(user, userRoles);

                var role = await rolesManager.FindByIdAsync(roleId);

                if (role is not null)
                    await usersManager.AddToRoleAsync(user, role.Name);

                return RedirectToAction("GetUsers");
            }
            return View(userId);
        }

        public async Task<ActionResult> DeleteUserAsync(string userId)
        {
            var user = await usersManager.FindByIdAsync(userId);
            await usersManager.DeleteAsync(user);
            return RedirectToAction("GetUsers");
        }
    }
}
