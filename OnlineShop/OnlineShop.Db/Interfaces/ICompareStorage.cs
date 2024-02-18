using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface ICompareStorage
    {
        Task AddAsync(Product product, string userName);
        Task RemoveAsync(Guid productId, string userName);
        Task ClearAsync(string userName);
        Task<List<Product>> GetAllAsync(string userName);
        Task MoveToUserCompareAsync(string fromUser, string toUser);
    }
}
