using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Helpers;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class CompareDbRepository : ICompareStorage
    {
        private readonly DataBaseContext dataBaseContext;

        public CompareDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task AddAsync(Product product, string userName)
        {
            var existingCompare = await dataBaseContext.Compares.FirstOrDefaultAsync(x => x.UserName == userName && x.Product.Id == product.Id);

            if (existingCompare is null)
                await dataBaseContext.Compares.AddAsync(new Compare() { UserName = userName, Product = product });
                
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid productId, string userName)
        {
            var existingItem = await dataBaseContext.Compares.FirstOrDefaultAsync(x => x.UserName == userName && x.Product.Id == productId);

            if (existingItem is not null)
                await dataBaseContext.Compares.Where(x => x.UserName == userName && x.Product.Id == productId)
                                              .ExecuteDeleteAsync();

            await dataBaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userName)
        {
            await dataBaseContext.Compares.Where(x => x.UserName == userName)
                                          .ExecuteDeleteAsync();

            await dataBaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync(string userName)
        {
            return await dataBaseContext.Compares.Where(x => x.UserName == userName)
                                                 .Include(x => x.Product)
                                                 .ThenInclude(x => x.Characteristics)
                                                 .Select(x => x.Product)
                                                 .ToListAsync();
        }

        public async Task MoveToUserCompareAsync(string fromUser, string toUser)
        {
            var fromCompare = await GetAllAsync(fromUser);

            var toCompare = await GetAllAsync(toUser);

            var items = fromCompare.Except(toCompare, new ProductIEqualityComparer())?
                                   .Select(x => new Compare() { UserName = toUser, Product = x });

            await dataBaseContext.Compares.AddRangeAsync(items);
            await dataBaseContext.SaveChangesAsync();
        }
    }
}
