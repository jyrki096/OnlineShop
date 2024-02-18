using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Basket
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketStorage basketStorage;

        public BasketViewComponent(IBasketStorage basketStorage)
        {
            this.basketStorage = basketStorage;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            var basketDB = await basketStorage.TryGetByUserNameAsync(userName);
            var amount = basketDB is null || basketDB.BasketItems.Count == 0? "" : basketDB.BasketItems.Sum(x => x.Amount).ToString();

            return View("Basket", amount);
        }
    }
}
