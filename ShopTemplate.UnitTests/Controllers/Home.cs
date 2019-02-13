using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ShopTemplate.Controllers;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.ViewModels;
using System.Linq;

namespace ShopTemplate.UnitTests.Controllers
{
    public class Home
    {
        [Test]
        public void ProductInfoExistingProduct()
        {
            //arrange
            HomeController homeController = new HomeController(Mocks.GetProductRepository());

            //act
            IActionResult result = homeController.ProductInfo(1);

            //arrange
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(Product), viewResult.Model.GetType());
        }

        [Test]
        public void ProductInfoUnexistingProduct()
        {
            //arrange
            HomeController homeController = new HomeController(Mocks.GetProductRepository());

            //act
            IActionResult result = homeController.ProductInfo(55);

            //arrange
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void Index()
        {
            //arrange
            HomeController homeController = new HomeController(Mocks.GetProductRepository());

            //act
            IActionResult result = homeController.Index("Fashion", Enums.ProductSortingOption.AZ, 1, 4);

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            ProductsViewModel productsViewModel = (ProductsViewModel)viewResult.Model;
            Assert.AreEqual(3, productsViewModel.Products.Count());
            Assert.IsNotNull(productsViewModel.Products.FirstOrDefault(p => p.Id == 2));
            Assert.IsNotNull(productsViewModel.Products.FirstOrDefault(p => p.Id == 4));
            Assert.IsNotNull(productsViewModel.Products.FirstOrDefault(p => p.Id == 6));
        }
    }
}
