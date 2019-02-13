using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Models;
using System.Linq;

namespace ShopTemplate.Domain.Services.Concrete.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext shopDbContext;

        public CategoryRepository(ShopDbContext shopDbContextParam)
        {
            shopDbContext = shopDbContextParam;
        }

        public IQueryable<Category> Categories
        {
            get
            {
                return shopDbContext.Categories;
            }
        }
    }
}
