using ShopTemplate.Domain.Models.Entities;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface IUserMessageRepository
    {
        Task AddAsync(UserMessage userMessage);
    }
}
