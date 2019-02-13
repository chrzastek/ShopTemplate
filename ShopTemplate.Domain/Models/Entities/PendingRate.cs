using ShopTemplate.Models;
using System;

namespace ShopTemplate.Domain.Models.Entities
{
    public partial class PendingRate
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
