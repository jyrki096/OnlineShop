using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> usersManager;
        private readonly IWebHostEnvironment appEnvironment;
        private readonly IOrderStorage orderStorage;
        private readonly IMapper mapper;

        public UserController(UserManager<User> usersManager, IWebHostEnvironment appEnvironment, IOrderStorage orderStorage, IMapper mapper)
        {
            this.usersManager = usersManager;
            this.appEnvironment = appEnvironment;
            this.orderStorage = orderStorage;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {  
            var user = await usersManager.FindByNameAsync(User.Identity.Name);
            return View(mapper.Map<UserViewModel>(user)); 
        }

        public async Task<ActionResult> EditUserAsync()
        {
            var user = await usersManager.FindByNameAsync(User.Identity.Name);
            return View(mapper.Map<UserViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> EditUserAsync(UserViewModel editedUser)
        {
            if (ModelState.IsValid)
            {
                var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/users");
                editedUser.Image = editedUser.UpPhoto is null ? editedUser.Image : ImageProvider.SaveImage(folderPath, editedUser.UpPhoto);
                var user = await usersManager.FindByNameAsync(User.Identity.Name);
                mapper.Map(editedUser, user);
                await usersManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }

            return View(editedUser);
        }

        public async Task<ActionResult> DeleteImageAsync()
        {
            var user = await usersManager.FindByNameAsync(User.Identity.Name);
            user.Image = "/images/users/NoAvatar12723.jpg";
            await usersManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UserOrdersAsync() 
        {
            var orders = await orderStorage.TryGetOrdersByNameAsync(User.Identity.Name);
            return View(mapper.Map<List<OrderViewModel>>(orders));
        }
    }
}
