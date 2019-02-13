using ShopTemplate.Domain.Models.Entities;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract.Utils
{
    public interface IOrderProcessor
    {
        Task ProcessAsync(Order order, string baseUrl);
    }
}
