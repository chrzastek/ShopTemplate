using ShopTemplate.Domain.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface IRatesRepository
    {
        Task AddAsync(Rate rate);
        Task AddPendingAsync(PendingRate pendingRate);
        IQueryable<Rate> GetRatesGivenByUser(string userId);
        IQueryable<PendingRate> GetPendingsForUser(string userId);
        Task RemovePendingAsync(string userId, int productId);
        bool PendingForUserWithItemExists(string userId, int productId);
    }
}
