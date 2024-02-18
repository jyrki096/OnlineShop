using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
		private readonly ProductCache productCache;

		public ProductController(ProductCache productCache, IMapper mapper)
        {  
            this.mapper = mapper;
            this.productCache = productCache;
        }

        public async Task<ActionResult> Index(Guid id)
        {
            var product = await productCache.TryGetByIdAsync(id);
			return View(mapper.Map<ProductViewModel>(product));
        }
    }
}
