using ShopTemplate.Models;
using System;

namespace ShopTemplate.Domain.Models.Entities
{
    public partial class PendingRate
    {
        public PendingRate() { }

        public PendingRate(Product product, string userId, DateTime purchaseDate)
        {
            Product = product;
            PurchaseDate = purchaseDate;
            User = new ApplicationUser();
            User.Id = userId;
        }
    }
}
