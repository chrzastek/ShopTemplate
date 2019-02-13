using Microsoft.EntityFrameworkCore;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Linq;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext shopDbContext;

        public ProductRepository(ShopDbContext shopDbContextParam)
        {
            shopDbContext = shopDbContextParam;
        }

        public IQueryable<Product> Products
        {
            get
            {
                return shopDbContext.Products.Include(p => p.Category);
            }
        }

        public int AmountOfProductsWithCategory(string category)
        {
             return shopDbContext.Products
                .Where(p => (p.Category.Name == category) || (category == null))
                .Count();
        }

        public Product GetProductById(int productId)
        {
            return shopDbContext.Products
                .Include(p => p.Rates)
                .ThenInclude(p => p.User)
                .FirstOrDefault(p => p.Id == productId);
        }
    }
}