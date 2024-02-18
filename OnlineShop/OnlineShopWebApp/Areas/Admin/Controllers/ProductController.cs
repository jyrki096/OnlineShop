using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly IWebHostEnvironment appEnvironment;
        private readonly IMapper mapper;

        public ProductController(IProductStorage productStorage, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            this.productStorage = productStorage;
            this.mapper = mapper;
            appEnvironment = webHostEnvironment;
        }

        public async Task<ActionResult> GetProductsAsync()
        {
            var productsDB = await productStorage.GetAllAsync();
            return View(mapper.Map<List<ProductViewModel>>(productsDB));
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProductAsync(ProductViewModel product)
        {
            var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/products");
            ImageProvider.SaveProductImages(folderPath, product);

            if (product.Name == product.Description)
                ModelState.AddModelError(string.Empty, "Имя и описание не должно совпадать");

            if (product.ImageLink is null)
                ModelState.AddModelError(string.Empty, "Добавьте изображение!");

            if (ModelState.IsValid)
            {
                var productDB = mapper.Map<Product>(product);
				await productStorage.AddAsync(productDB);
                return RedirectToAction("GetProducts");
            }
                   
            return View(product);
        }

        public async Task<ActionResult> EditProductAsync(Guid productId)
        {
            var product = await productStorage.GetProductByIdAsync(productId);
            return View(mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public async Task<ActionResult> EditProductAsync(ProductViewModel editedProduct)
        {      
            var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/products");
            ImageProvider.SaveProductImages(folderPath, editedProduct);

            if (editedProduct.Name == editedProduct.Description)
                ModelState.AddModelError(string.Empty, "Имя и описание не должны совпадать");

            if (ModelState.IsValid)
            {
                var productDB = await productStorage.GetProductByIdAsync(editedProduct.Id);
                var oldLinks = string.Join(";", productDB.ImageLinks);
                editedProduct.ImageLinks = editedProduct.UpFiles is null ? oldLinks.Split(';').ToList() : editedProduct.ImageLinks;      
                mapper.Map(editedProduct, productDB);
                await productStorage.EditAsync();
                return RedirectToAction("GetProducts");
            }
            return View(editedProduct);
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        { 
		    await productStorage.RemoveAsync(productId);
            return RedirectToAction("GetProducts");
        }
    }
}
