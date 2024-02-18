using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class ProductDbRepository : IProductStorage
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dataBaseContext.Products.Include(x => x.Characteristics)
                                                 .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await dataBaseContext.Products.Include(x => x.Characteristics).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await dataBaseContext.Products.Include(x => x.Characteristics)
                                                 .Where(x => x.Name.ToLower()
                                                 .Contains(name.ToLower()))
                                                 .ToListAsync();
		}

        public async Task AddAsync(Product product)
        {
            await dataBaseContext.Products.AddAsync(product);
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task EditAsync()
        {
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid productId)
        {
            await dataBaseContext.Products.Where(x => x.Id == productId).ExecuteDeleteAsync();
			await dataBaseContext.SaveChangesAsync();
		}
    }
}
