using ShopTemplate.Domain.Models.Entities;
using System.Linq;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product GetProductById(int productId);
        int AmountOfProductsWithCategory(string category);
    }
}
