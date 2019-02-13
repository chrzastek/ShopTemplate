using Microsoft.EntityFrameworkCore;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext shopDbContext;

        public OrderRepository(ShopDbContext shopDbContextParam)
        {
            shopDbContext = shopDbContextParam;
        }

        public async Task AddAsync(Order order)
        {
            await shopDbContext.Orders.AddAsync(order);
            await shopDbContext.SaveChangesAsync();
        }

        public Order GetById(int orderId)
        {
            return shopDbContext.Orders
                .Include(o => o.ProductOrders)
                .ThenInclude(o => o.Product)
                .FirstOrDefault(o => o.Id == orderId);
        }

        public IQueryable<Order> GetUserOrders(string userId)
        {
            return shopDbContext.Orders.Where(o => o.User.Id == userId);
        }
    }
}
