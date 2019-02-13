using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.ViewComponents
{
    public class AddressViewComponent : ViewComponent
    {
        private readonly IMapper mapper;
        private readonly IAddressRepository addressRepository;
        private readonly ApplicationUserManager applicationUserManager;

        public AddressViewComponent(IMapper mapper, IAddressRepository addressRepository, ApplicationUserManager applicationUserManager)
        {
            this.mapper = mapper;
            this.addressRepository = addressRepository;
            this.applicationUserManager = applicationUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User != null)
            {
                string userName = HttpContext.User.Identity.Name;
                string userId = await applicationUserManager.GetUserIdByNameAsync(userName);
                Address address = addressRepository.GetUserAddress(userId);
                AddressDataViewModel addressDataViewModel = mapper.Map<AddressDataViewModel>(address);

                return View(addressDataViewModel);
            }

            return null;
        }
    }
}
