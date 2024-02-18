using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Db.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Avatar
{
    public class AvatarViewComponent : ViewComponent
    {
        private readonly UserManager<User> usersManager;
        private readonly IMemoryCache cache;

        public AvatarViewComponent(UserManager<User> usersManager, IMemoryCache cache)
        {
            this.usersManager = usersManager;
            this.cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = User.Identity.Name; 
            cache.TryGetValue(userName, out var avatar);
            
            if (avatar is null)
            {
                avatar = (await usersManager.FindByNameAsync(userName)).Image;
                cache.Set(userName, avatar, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
            }
     
            return View("Avatar", avatar);
        }
    }
}
