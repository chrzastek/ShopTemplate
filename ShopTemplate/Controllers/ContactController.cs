using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Models;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;

namespace ShopTemplate.Controllers
{
    public class ContactController : ApplicationController
    {
        private readonly IUserMessageRepository userMessageRepository;

        public ContactController(ApplicationUserManager applicationUserManager, IUserMessageRepository userMessageRepository)
            :base(applicationUserManager)
        {
            this.userMessageRepository = userMessageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl)
        {
            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.ReturnUrl = returnUrl;

            string userName = HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                ApplicationUser applicationUser = await GetCurrentUser();
                contactViewModel.SenderEmail = applicationUser.Email;
            }

            return View(contactViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel contactViewModel)
        {
            if(ModelState.IsValid)
            {
                UserMessage userMessage = new UserMessage();
                userMessage.Body = contactViewModel.Message;
                userMessage.SenderEmail = contactViewModel.SenderEmail;
                userMessage.Read = false;

                string userName = HttpContext.User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                    userMessage.ApplicationUser = await GetCurrentUser();

                await userMessageRepository.AddAsync(userMessage);
                
                TempData["msg"] = "Your message has been sent! We will answer you as soon as possible.";
                return Redirect(Url.Content("/" + contactViewModel.ReturnUrl));
            }
            else
            {
                contactViewModel.SenderEmail = null;
                return View(contactViewModel);
            }
        }
    }
}