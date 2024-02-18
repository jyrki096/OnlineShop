using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.IO;
using System.Threading.Tasks;



namespace OnlineShopWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IBasketStorage basketStorage;
        private readonly ICompareStorage compareStorage;
        private readonly IFavoriteStorage favoriteStorage;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment appEnvironment;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IBasketStorage basketStorage, ICompareStorage compareStorage, IFavoriteStorage favoriteStorage, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.basketStorage = basketStorage;
            this.compareStorage = compareStorage;
            this.favoriteStorage = favoriteStorage;
            this.mapper = mapper;
            this.appEnvironment = appEnvironment;
        }

        public async Task<ActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (user is not null)
                return View(mapper.Map<UserViewModel>(user));

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Enter(string returnUrl)
        {
            return View(new Auth() { ReturnUrl = returnUrl  ?? "/Home" });
        }
        
        [HttpPost]
        public async Task<IActionResult> EnterAsync(Auth auth)
        {
            if (auth.Login == auth.Password)
                ModelState.AddModelError(string.Empty, "Имя и пароль не должны совпадать");

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(auth.Login, auth.Password, auth.IsRemember, false);

                if (result.Succeeded)
                {
                    await basketStorage.MoveToUserBasketAsync(Request.Cookies["id"], auth.Login);
                    await compareStorage.MoveToUserCompareAsync(Request.Cookies["id"], auth.Login);
                    await favoriteStorage.MoveToUserFavoriteAsync(Request.Cookies["id"], auth.Login);
                    return Redirect(auth.ReturnUrl ?? "/Home");
                }
 
                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
            }
            return View(auth);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Register register)
        {
            if (register.Login == register.Name)
                ModelState.AddModelError(string.Empty, "Логин и имя не должны совпадать");

            if ((await userManager.FindByEmailAsync(register.Login)) is not null)
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

                var result = await userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    await basketStorage.MoveToUserBasketAsync(Request.Cookies["id"], user.Email);
                    await compareStorage.MoveToUserCompareAsync(Request.Cookies["id"], user.Email);
                    await favoriteStorage.MoveToUserFavoriteAsync(Request.Cookies["id"], user.Email);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(register);
        }

        public async Task<ActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
