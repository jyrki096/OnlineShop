using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class OrderDbRepository : IOrderStorage
    {
        private readonly DataBaseContext dataBaseContext;

        public OrderDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task AddAsync(Order order)
        {
            await dataBaseContext.Orders.AddAsync(order);
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task<List<Order>> TryGetAllAsync()
        {
            return await dataBaseContext.Orders.ToListAsync();
        }

        public async Task<Order> TryGetOrderByIdAsync(Guid orderId)
        {
            return await dataBaseContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<List<Order>> TryGetOrdersByNameAsync(string userName)
        {
            return await dataBaseContext.Orders.Where(x => x.UserName == userName).ToListAsync();
        }

        public async Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            var order = await TryGetOrderByIdAsync(orderId);

            if (order is not null)
                order.Status = newStatus;

            await dataBaseContext.SaveChangesAsync();
        }
    }
}
