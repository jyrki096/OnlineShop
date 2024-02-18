using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IOrderStorage
    {
        Task AddAsync(Order order);
        Task<List<Order>> TryGetAllAsync();
        Task<Order> TryGetOrderByIdAsync(Guid orderId);
        Task<List<Order>> TryGetOrdersByNameAsync(string userName);
        Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus);
    }
}
