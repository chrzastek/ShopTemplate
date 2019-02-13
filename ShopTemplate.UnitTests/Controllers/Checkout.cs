using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ShopTemplate.Controllers;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;


namespace ShopTemplate.UnitTests.Controllers
{
    public class Checkout
    {
        [Test]
        public async Task DisplayCheckout_IndexGet()
        {
            //arrange
            CheckoutController checkoutController = new CheckoutController(Mocks.GetAddressRepository(),
                Mocks.GetPaymentTypesRepository(), Mocks.GetMapper(), Mocks.GetMockUserManager(),
                Mocks.GetProductRepository(), Mocks.GetOrderProcessor());
            Mocks.FillController(checkoutController);

            //act
            IActionResult result = await checkoutController.Index(Mocks.GetCart());
            
            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(CheckoutViewModel), viewResult.Model.GetType());
        }

        [Test]
        public async Task DisplayCheckout_IndexPost()
        {
            //arrange
            CheckoutController checkoutController = new CheckoutController(Mocks.GetAddressRepository(), Mocks.GetPaymentTypesRepository(),
                Mocks.GetMapper(), Mocks.GetMockUserManager(), Mocks.GetProductRepository(), Mocks.GetOrderProcessor());
            Mocks.FillController(checkoutController);
            CheckoutViewModel checkoutViewModel = new CheckoutViewModel { Cart = Mocks.GetCart() };

            //act
            IActionResult result = await checkoutController.Index(checkoutViewModel);

            //assert
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }
    }
}
