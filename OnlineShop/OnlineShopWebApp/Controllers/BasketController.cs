using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Controllers
{

    public class BasketController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly IBasketStorage basketStorage;
        private readonly IMapper mapper;

        public BasketController(IProductStorage productStorage, IBasketStorage basketStorage, IMapper mapper)
        {
            this.productStorage = productStorage;
            this.basketStorage = basketStorage;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            var basketDB = await basketStorage.TryGetByUserNameAsync(user);
            return View(mapper.Map<BasketViewModel>(basketDB));
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
            await basketStorage.AddAsync(productDB, user);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ReduceAsync(Guid productId)
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            await basketStorage.ReduceAsync(productId, user);   
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ClearAsync() 
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            await basketStorage.ClearAsync(user);
            return RedirectToAction("Index");
        }
    }
}
