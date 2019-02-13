using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Enums;
using ShopTemplate.Extensions;
using ShopTemplate.ViewModels;
using System.Linq;

namespace ShopTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepositoryParam)
        {
            productRepository = productRepositoryParam;
        }

        [HttpGet]
        public IActionResult Index(string category, ProductSortingOption sortingOption, int pageNumber = 1, int itemsPerPage = 4)
        {
            ProductsViewModel productsViewModel = new ProductsViewModel()
            {
                Products = productRepository.Products
                    .Where(p => p.Category.Name == category || category == null)
                    .SortBy(sortingOption)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage),

                PaginateData = GetPaginateData(category, pageNumber, itemsPerPage)
            };

            return View(productsViewModel);
        }

        private PaginateData GetPaginateData(string category, int pageNumber, int itemsPerPage)
        {
            int itemsWithCategory = productRepository.AmountOfProductsWithCategory(category);

            int numberOfPages = itemsWithCategory % itemsPerPage == 0 ?
                itemsWithCategory / itemsPerPage : itemsWithCategory / itemsPerPage + 1;

            return new PaginateData()
            {
                Category = category,
                CurrentPage = pageNumber,
                NumberOfPages = numberOfPages
            };
        }

        [HttpGet]
        public IActionResult ProductInfo(int productId)
        {
            Product product = productRepository.GetProductById(productId);
            if (product != null)
                return View(product);
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult About() => View();
    }
}
