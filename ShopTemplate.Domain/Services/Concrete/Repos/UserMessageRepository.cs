using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class UserMessageRepository : IUserMessageRepository
    {
        private readonly ShopDbContext shopDbContext;

        public UserMessageRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public async Task AddAsync(UserMessage userMessage)
        {
            await shopDbContext.UserMessages.AddAsync(userMessage);
            await shopDbContext.SaveChangesAsync();
        }
    }
}
