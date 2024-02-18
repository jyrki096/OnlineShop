using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IFavoriteStorage
    {
        Task AddAsync(Product product, string userName);
        Task RemoveAsync(Guid productId, string userName);
        Task ClearAsync(string userName);
        Task<List<Product>> GetAllAsync(string userName);
        Task MoveToUserFavoriteAsync(string fromUser, string toUser);
    }
}
