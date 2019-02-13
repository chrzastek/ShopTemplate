using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTemplate.Domain.Models.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Rate> Rates { get; set; }
    }
}
