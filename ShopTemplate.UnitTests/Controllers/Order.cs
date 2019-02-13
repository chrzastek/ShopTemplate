using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ShopTemplate.Controllers;
using System.Threading.Tasks;

namespace ShopTemplate.UnitTests.Controllers
{
    public class Order
    {
        [Test]
        public void DetailsExistingOrder()
        {
            //arrange
            OrderController orderController = new OrderController(Mocks.GetOrderRepository(), Mocks.GetMockUserManager());

            //act
            IActionResult result = orderController.Details(1);

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(Domain.Models.Entities.Order), viewResult.Model.GetType());
        }

        [Test]
        public void DetailsUnexistingOrder()
        {
            //arrange
            OrderController orderController = new OrderController(Mocks.GetOrderRepository(), Mocks.GetMockUserManager());

            //act
            IActionResult result = orderController.Details(55);

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public async Task Index()
        {
            //arrange
            OrderController orderController = new OrderController(Mocks.GetOrderRepository(), Mocks.GetMockUserManager());
            Mocks.FillController(orderController);
            //act
            IActionResult result = await orderController.Index(Enums.OrderSortingType.None, Enums.OrderSortingOption.None);

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }
    }
}
