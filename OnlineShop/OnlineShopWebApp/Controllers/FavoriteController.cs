using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteStorage favoriteStorage;
        private readonly IProductStorage productStorage;
        private readonly IMapper mapper;

        public FavoriteController(IFavoriteStorage favoriteStorage, IProductStorage productStorage, IMapper mapper)
        {
            this.favoriteStorage = favoriteStorage;
            this.productStorage = productStorage;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            var favorites = await favoriteStorage.GetAllAsync(user);
            return View(mapper.Map<List<ProductViewModel>>(favorites));
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var user = User.Identity.Name;

            if (user is null)
            {
                var cookieValue = Request.Cookies["id"];
                if (cookieValue == null)
                {
                    cookieValue = Guid.NewGuid().ToString() + DateTime.Now.ToString("d");
                    var cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("id", cookieValue, cookie);
                }
                user = cookieValue;
            }
            var productDB = await productStorage.GetProductByIdAsync(productId);
            await favoriteStorage.AddAsync(productDB, user);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteAsync(Guid productId)
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            await favoriteStorage.RemoveAsync(productId, user);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ClearAsync()
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            await favoriteStorage.ClearAsync(user);
            return RedirectToAction("Index");
        }
    }
}
