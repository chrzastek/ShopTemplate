using Microsoft.EntityFrameworkCore;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class RatesRepository : IRatesRepository
    {
        private readonly ShopDbContext shopDbContext;

        public RatesRepository(ShopDbContext shopDbContextParam)
        {
            shopDbContext = shopDbContextParam;
        }

        public async Task AddAsync(Rate rate)
        {
            if (!UserRateForProductExists(rate.Product.Id, rate.User.Id))
            {
                await shopDbContext.Rates.AddAsync(rate);
                await shopDbContext.SaveChangesAsync();
            }
        }

        public async Task AddPendingAsync(PendingRate pendingRate)
        {
            if(!PendingForUserWithItemExists(pendingRate.User.Id, pendingRate.Product.Id) 
                &&
               !UserRateForProductExists(pendingRate.Product.Id, pendingRate.User.Id))
            {
                shopDbContext.PendingRates.Add(pendingRate);
                await shopDbContext.SaveChangesAsync();
            }
        }

        public IQueryable<Rate> GetRatesGivenByUser(string userId)
        {
            return shopDbContext.Rates
                .Include(r => r.Product)
                .Where(r => r.User.Id == userId);
        }

        public IQueryable<PendingRate> GetPendingsForUser(string userId)
        {
            return shopDbContext.PendingRates
                .Include(pr => pr.Product).Where(pr => pr.User.Id == userId);
        }

        public async Task RemovePendingAsync(string userId, int productId)
        {
            PendingRate pendingRateToRemove = shopDbContext.PendingRates
                .FirstOrDefault(pr => pr.User.Id == userId && pr.Product.Id == productId);

            if(pendingRateToRemove != null)
            {
                shopDbContext.PendingRates.Remove(pendingRateToRemove);
                await shopDbContext.SaveChangesAsync();
            }
        }

        public bool PendingForUserWithItemExists(string userId, int productId)
        {
            PendingRate pendingRate = shopDbContext.PendingRates
                .FirstOrDefault(pr => pr.User.Id == userId && pr.Product.Id == productId);

            return pendingRate != null;
        }

        public bool UserRateForProductExists(int productId, string userId)
        {
            Rate rate = shopDbContext.Rates
                .FirstOrDefault(r => r.Product.Id == productId && r.User.Id == userId);

            return rate != null;
        }
    }
}
