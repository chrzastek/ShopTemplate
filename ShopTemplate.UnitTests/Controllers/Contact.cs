using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ShopTemplate.Controllers;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;

namespace ShopTemplate.UnitTests.Controllers
{
    public class Contact
    {
        [Test]
        public async Task DisplayContact_IndexGet()
        {
            //arrange
            ContactController contactController = new ContactController(Mocks.GetMockUserManager(), 
                Mocks.GetUserMessageRepository());
            Mocks.FillController(contactController);

            //act
            IActionResult result = await contactController.Index("returnUrl");

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(ContactViewModel), viewResult.Model.GetType());
            ContactViewModel contactViewModel = (ContactViewModel)viewResult.Model;
            Assert.IsNotNull(contactViewModel.SenderEmail);
        }

        [Test]
        public void DisplayContact_IndexPost()
        {
            //arrange
            ContactController contactController = new ContactController(Mocks.GetMockUserManager(),
                Mocks.GetUserMessageRepository());
            Mocks.FillController(contactController);

            //act
            //IActionResult result = await contactController.Index(new ContactViewModel { ReturnUrl = "returnUrl" });

            //assert
        }

        [Test]
        public async Task DisplayContactModelError_IndexGet()
        {
            //arrange
            ContactController contactController = new ContactController(Mocks.GetMockUserManager(),
                Mocks.GetUserMessageRepository());
            Mocks.FillController(contactController);
            contactController.ModelState.AddModelError("", "");

            //act
            IActionResult result = await contactController.Index(new ContactViewModel());

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(typeof(ContactViewModel), viewResult.Model.GetType());
            ContactViewModel contactViewModel = (ContactViewModel)viewResult.Model;
            Assert.IsNull(contactViewModel.SenderEmail);
        }
    }
}
