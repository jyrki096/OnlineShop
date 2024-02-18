using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Views.Shared.Components.Favorite
{
    public class FavoriteViewComponent : ViewComponent
    {
        private readonly IFavoriteStorage favoriteStorage;

        public FavoriteViewComponent(IFavoriteStorage favoriteStorage)
        {
            this.favoriteStorage = favoriteStorage;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            var favoriteDB = await favoriteStorage.GetAllAsync(user);
            var amount = favoriteDB is null || favoriteDB.Count == 0 ? "" : favoriteDB.Count.ToString();
            return View("Favorite", amount);
        }
    }
}
