using ShopTemplate.Domain.Models.Entities;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface IAddressRepository
    {
        Address GetUserAddress(string userId);
        Address GetAddressById(string id);
        Task SaveChangesAsync();
    }
}
