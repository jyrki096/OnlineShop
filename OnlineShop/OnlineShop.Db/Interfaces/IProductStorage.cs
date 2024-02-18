using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IProductStorage
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task RemoveAsync(Guid productId);
        Task EditAsync();
        Task<List<Product>> GetProductsByNameAsync(string name);
    }
}
