using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IBasketStorage
    {
        Task AddAsync(Product product, string userName);
        Task ReduceAsync(Guid productId, string userName);
        Task ClearAsync(string userName);
        Task<Basket> TryGetByUserNameAsync(string userName);
        Task<decimal> GetCostAsync(string userName);
        Task MoveToUserBasketAsync(string fromUser, string toUser);
	}
}
