using ShopTemplate.Models;
using System;

namespace ShopTemplate.Domain.Models.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new Product();
        public string Text { get; set; }
        public int Rating { get; set; }
        public ApplicationUser User { get; set; } = new ApplicationUser();
        public DateTime AddedDate { get; set; }
    }
}
