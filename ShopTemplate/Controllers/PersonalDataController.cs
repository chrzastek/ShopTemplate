using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Models;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;

namespace ShopTemplate.Controllers
{
    [Authorize]
    public class PersonalDataController : ApplicationController
    {
        private readonly IMapper mapper;
        private readonly IAddressRepository addressRepository;

        public PersonalDataController(IAddressRepository addressRepository, IMapper mapper, ApplicationUserManager applicationUserManager)
            :base(applicationUserManager)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApplicationUser applicationUser = await GetCurrentUser();

            AccountDataViewModel accountDataViewModel = new AccountDataViewModel
            {
                Name = applicationUser.UserName,
                Email = applicationUser.Email,
                EmailConfirmed = applicationUser.EmailConfirmed
            };

            return View(accountDataViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddressDataViewModel addressData)
        {
            if(ModelState.IsValid)
            {
                Address address = addressRepository.GetAddressById(addressData.Id);
                mapper.Map(addressData, address, typeof(AddressDataViewModel), typeof(Address));
                await addressRepository.SaveChangesAsync();

                TempData["msg"] = "Address changes has been saved!";
                return RedirectToAction("Index");
            }
            else
                return View(addressData);
        }
    }
}