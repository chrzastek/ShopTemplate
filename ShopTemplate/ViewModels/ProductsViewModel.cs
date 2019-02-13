using ShopTemplate.Domain.Models.Entities;
using System.Collections.Generic;

namespace ShopTemplate.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PaginateData PaginateData { get; set; }
    }

    public class PaginateData
    {
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public string Category { get; set; }
    }
}
