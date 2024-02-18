using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System.Threading.Tasks;



namespace OnlineShopWebApp.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareStorage compareStorage;

        public CompareViewComponent(ICompareStorage compareStorage)
        {
            this.compareStorage = compareStorage;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : Request.Cookies["id"];
            var compareDB = await compareStorage.GetAllAsync(user);
            var amount = compareDB is null || compareDB.Count == 0 ? "" : compareDB.Count.ToString();
            return View("Compare", amount);
        }
    }
}
