using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ShopTemplate.Controllers;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;

namespace ShopTemplate.UnitTests.Controllers
{
    public class Rates
    {
        [Test]
        public async Task IndexGet()
        {
            //arrange
            RatesController ratesController = new RatesController(Mocks.GetMapper(), Mocks.GetRatesRepository(),
                Mocks.GetProductRepository(), Mocks.GetMockUserManager());
            Mocks.FillController(ratesController);

            //act
            IActionResult result = await ratesController.Index();

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(RatesViewModel), viewResult.Model.GetType());
        }

        [Test]
        public async Task RateWhenPendingExists()
        {
            //arrange
            RatesController ratesController = new RatesController(Mocks.GetMapper(), Mocks.GetRatesRepository(),
                Mocks.GetProductRepository(), Mocks.GetMockUserManager());
            Mocks.FillController(ratesController);

            //act
            IActionResult result = await ratesController.Rate(1);

            //assert 
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
        }

        [Test]
        public async Task RateWhenPendingDontExist()
        {
            //arrange
            RatesController ratesController = new RatesController(Mocks.GetMapper(), Mocks.GetRatesRepository(),
                Mocks.GetProductRepository(), Mocks.GetMockUserManager());
            Mocks.FillController(ratesController);

            //act
            IActionResult result = await ratesController.Rate(20);

            //assert 
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }
    }
}
