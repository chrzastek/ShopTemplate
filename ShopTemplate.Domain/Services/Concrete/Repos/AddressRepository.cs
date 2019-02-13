using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShopDbContext shopDbContext;

        public AddressRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public Address GetAddressById(string id)
        {
            return shopDbContext.Addresses.FirstOrDefault(a => a.Id == id);
        }

        public Address GetUserAddress(string userId)
        {
            return shopDbContext.Addresses.FirstOrDefault(a => a.User.Id == userId);
        }

        public async Task SaveChangesAsync()
        {
            await shopDbContext.SaveChangesAsync();
        }
    }
}
