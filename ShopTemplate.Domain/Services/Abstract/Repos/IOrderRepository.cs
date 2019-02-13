using ShopTemplate.Domain.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Order GetById(int orderId);
        IQueryable<Order> GetUserOrders(string userId);
    }
}
