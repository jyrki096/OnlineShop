using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Helpers
{
	public class ProductCache 
	{
		private readonly IMemoryCache cache;
		private readonly IProductStorage storage;

        public ProductCache(IProductStorage storage, IMemoryCache cache)
        {
			this.cache = cache;
			this.storage = storage;
        }

		public async Task<List<Product>> TryGetAllProductsAsync()
		{
			cache.TryGetValue<List<Product>>(Constants.ProductsKeyCache, out var products);
		
			if (products is null)
			{
				await CacheProductsAsync();
				cache.TryGetValue(Constants.ProductsKeyCache, out products);
			}

			return products;
		}

		public async Task<Product> TryGetByIdAsync(Guid id)
		{
			cache.TryGetValue<Product>(id, out var product);

			if (product is null)
			{
				await CacheProductsAsync();
				cache.TryGetValue(id, out product);
			}

			return product;
		}

		public async Task CacheProductsAsync()
		{
			var products = await storage.GetAllAsync();

			if (products is null || !products.Any())
				return;

			cache.Set(Constants.ProductsKeyCache, products, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));

			foreach (var product in products)
			{
				cache.Set(product.Id, product);
			}
		}
	}
}
