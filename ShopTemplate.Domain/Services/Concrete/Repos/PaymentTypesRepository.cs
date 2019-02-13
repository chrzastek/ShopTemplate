using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Linq;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class PaymentTypesRepository : IPaymentTypesRepository
    {
        private readonly ShopDbContext shopDbContext;

        public PaymentTypesRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public IQueryable<PaymentType> GetAllEnabled() => shopDbContext.PaymentTypes.Where(pt => pt.Enabled == true);
    }
}
