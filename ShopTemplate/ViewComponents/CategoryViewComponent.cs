using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryViewComponent(ICategoryRepository categoryRepositoryParam)
        {
            categoryRepository = categoryRepositoryParam;
        }

        public async Task<IViewComponentResult> InvokeAsync(string selectedCategory)
        {
            return View(new CategoriesViewModel()
            {
                Categories = await categoryRepository.Categories.Select(c => c.Name).ToListAsync(),
                SelectedCategory = selectedCategory
            });
        }
    }
}
