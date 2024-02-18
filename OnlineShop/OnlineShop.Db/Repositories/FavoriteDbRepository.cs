using OnlineShop.Db.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Helpers;

namespace OnlineShop.Db.Repositories
{
    public class FavoriteDbRepository : IFavoriteStorage
    {
        private readonly DataBaseContext dataBaseContext;

        public FavoriteDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task AddAsync(Product product, string userName)
        {
            var existingCompare = await dataBaseContext.Favorites.FirstOrDefaultAsync(x => x.UserName == userName && x.Product.Id == product.Id);

            if (existingCompare is null)
                await dataBaseContext.Favorites.AddAsync(new Favorite() { UserName = userName, Product = product });

            await dataBaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid productId, string userName)
        {
            var existingItem = await dataBaseContext.Favorites.FirstOrDefaultAsync(x => x.UserName == userName && x.Product.Id == productId);

            if (existingItem is not null)
                await dataBaseContext.Favorites.Where(x => x.UserName == userName && x.Product.Id == productId)
                                               .ExecuteDeleteAsync();

            await dataBaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userName)
        {
            await dataBaseContext.Favorites.Where(x => x.UserName == userName)
                                           .ExecuteDeleteAsync(); 

            await dataBaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync(string userName)
        {
            return await dataBaseContext.Favorites.Where(x => x.UserName == userName)
                                                  .Include(x => x.Product)
                                                  .ThenInclude(x => x.Characteristics)
                                                  .Select(x => x.Product)
                                                  .ToListAsync();
        }

        public async Task MoveToUserFavoriteAsync(string fromUser, string toUser)
        {
            var fromFavorite = await GetAllAsync(fromUser);
            
            var toFavorite = await GetAllAsync(toUser);

            var items = fromFavorite.Except(toFavorite, new ProductIEqualityComparer())?
                                    .Select(x => new Favorite() { UserName = toUser, Product = x });
                      
            await dataBaseContext.Favorites.AddRangeAsync(items);
            await dataBaseContext.SaveChangesAsync();
        }
    }
}
