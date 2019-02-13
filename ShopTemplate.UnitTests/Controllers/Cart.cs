using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ShopTemplate.Controllers;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.ViewModels;

namespace ShopTemplate.UnitTests.Controllers
{
    public class Cart
    {
        [Test]
        public void AddExistingProduct()
        {
            //arrange
            CartController cartController = new CartController(Mocks.GetProductRepository());

            //act
            IActionResult result = cartController.Add(1, Mocks.GetCart(), "returnUrl");

            //assert
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }

        [Test]
        public void AddUnexistingProduct()
        {
            //arrange
            CartController cartController = new CartController(Mocks.GetProductRepository());

            //act
            IActionResult result = cartController.Add(55, Mocks.GetCart(), "returnUrl");

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void RemoveExistingProduct()
        {
            //arrange
            CartController cartController = new CartController(Mocks.GetProductRepository());

            //act
            IActionResult result = cartController.Remove(1, Mocks.GetCart());

            //assert
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }

        [Test]
        public void RemoveUnexistingProduct()
        {
            //arrange
            CartController cartController = new CartController(Mocks.GetProductRepository());

            //act
            IActionResult result = cartController.Remove(55, Mocks.GetCart());

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void Summary()
        {
            //arrange
            CartController cartController = new CartController(Mocks.GetProductRepository());

            //act
            IActionResult result = cartController.CartSummary(Mocks.GetCart(), "");

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.IsAssignableFrom<CartSummaryViewModel>(viewResult.ViewData.Model);
        }

        [Test]
        public void Clear()
        {
            //arrange
            CartController cartController = new CartController(Mocks.GetProductRepository());

            //act
            IActionResult result = cartController.Clear(Mocks.GetCart());

            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }
    }
}
