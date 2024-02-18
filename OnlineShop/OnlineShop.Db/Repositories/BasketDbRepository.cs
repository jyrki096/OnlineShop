using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class BasketDbRepository : IBasketStorage
    {
        private readonly DataBaseContext databaseContext;

        public BasketDbRepository(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Basket> TryGetByUserNameAsync(string userName)
        {
            return await databaseContext.Baskets.Include(x => x.BasketItems)
                                                .ThenInclude(x => x.Product)
                                                .ThenInclude(x => x.Characteristics)
                                                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task AddAsync(Product product, string userName)
        {
            var existingBasket = await TryGetByUserNameAsync(userName);

            if (existingBasket is null)
            {
                var basket = new Basket()
                {
                    UserName = userName,
                };

                basket.BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Amount = 1,
                        Product = product,
                        Basket = basket
                    }
                };
               await databaseContext.Baskets.AddAsync(basket);
            }
            else
            {
                var item = existingBasket.BasketItems.FirstOrDefault(x => x.Product.Id == product.Id);

                if (item is null)
                    existingBasket.BasketItems.Add(new BasketItem()
                    {
                        Amount = 1,
                        Product = product,
                        Basket = existingBasket
                    });
                else
                    item.Amount++;
            }

            await databaseContext.SaveChangesAsync();
        }

        public async Task ReduceAsync(Guid productId, string userName)
        {
            var existingBasket = await TryGetByUserNameAsync(userName);
            var item = existingBasket.BasketItems.FirstOrDefault(x => x.Product.Id == productId);

            if (item is null)
                return;

            item.Amount--;

            if (item.Amount == 0)
                await databaseContext.BasketItems.Where(x => x.Product.Id == productId).ExecuteDeleteAsync();

            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userName)
        {
            var existingBasket = await TryGetByUserNameAsync(userName);

            if (existingBasket is null) 
                return;

            await databaseContext.Baskets.Where(x => x.UserName == userName).ExecuteDeleteAsync();
            await databaseContext.SaveChangesAsync();
        }

        public async Task<decimal> GetCostAsync(string userName)
        {
            return (await TryGetByUserNameAsync(userName)).BasketItems.Select(x => x.Amount * x.Product.Cost).Sum();
        }

        public async Task MoveToUserBasketAsync(string fromUser, string toUser)
        {
            var fromBasket = await TryGetByUserNameAsync(fromUser);

            if (fromBasket == null) 
                return;

            var userBasket = await TryGetByUserNameAsync(toUser);

            if (userBasket == null)
            {
                fromBasket.UserName = toUser;
                await databaseContext.SaveChangesAsync();
                return;
            }

            var resultBasket = new Basket()
            {
                UserName = toUser,
            };

            var unionItems = fromBasket.BasketItems.Union(userBasket.BasketItems)
                                                    .GroupBy(x => x.Product.Id)
                                                    .Select(x => new BasketItem()
                                                    {
                                                        Amount = x.Sum(x => x.Amount),
                                                        Product = x.First().Product,
                                                        Basket = resultBasket
                                                    }).ToList();

            resultBasket.BasketItems = unionItems;
            await databaseContext.AddAsync(resultBasket);
            await ClearAsync(fromUser);
            await ClearAsync(toUser);
        }
    }
}
