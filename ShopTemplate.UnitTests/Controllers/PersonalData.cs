using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ShopTemplate.Controllers;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;

namespace ShopTemplate.UnitTests.Controllers
{
    public class PersonalData
    {
        [Test]
        public async Task IndexGet()
        {
            //arrange
            PersonalDataController personalDataController 
                = new PersonalDataController(Mocks.GetAddressRepository(), Mocks.GetMapper(), Mocks.GetMockUserManager());
            Mocks.FillController(personalDataController);

            //act
            IActionResult result = await personalDataController.Index();

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(AccountDataViewModel), viewResult.Model.GetType());
        }

        [Test]
        public async Task IndexPostValidModel()
        {
            //arrange
            PersonalDataController personalDataController
                = new PersonalDataController(Mocks.GetAddressRepository(), Mocks.GetMapper(), Mocks.GetMockUserManager());
            Mocks.FillController(personalDataController);

            //act
            IActionResult result = await personalDataController.Index(new AddressDataViewModel());

            //assert
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }

        [Test]
        public async Task IndexPostInvalidModel()
        {
            //arrange
            PersonalDataController personalDataController
                = new PersonalDataController(Mocks.GetAddressRepository(), Mocks.GetMapper(), Mocks.GetMockUserManager());
            Mocks.FillController(personalDataController);
            personalDataController.ModelState.AddModelError("", "");

            //act
            IActionResult result = await personalDataController.Index(new AddressDataViewModel());

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(AddressDataViewModel), viewResult.Model.GetType());
        }
    }
}
