using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
	{
        private readonly IMapper mapper;
		private readonly ProductCache productCache;

        public HomeController(IMapper mapper, ProductCache productCache)
		{
			this.mapper = mapper;
			this.productCache = productCache;
		}

		public async Task<ActionResult> Index()
		{
			var products = await productCache.TryGetAllProductsAsync();
            return View(mapper.Map<List<ProductViewModel>>(products));
        }

		[HttpPost]
		public async Task<ActionResult> SearchAsync(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return View();

			var products = await productCache.TryGetAllProductsAsync();
			var searched = products.Where(x => x.Name.ToLower().Trim().Contains(name.ToLower().Trim()));	

            return View(mapper.Map<List<ProductViewModel>>(searched));
		}
	}
}
