using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Abstract.Utils;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.ShopCart;
using ShopTemplate.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.Controllers
{
    [Authorize]
    public class CheckoutController : ApplicationController
    {
        private readonly IMapper mapper;
        private readonly IAddressRepository addressRepository;
        private readonly IPaymentTypesRepository paymentTypesRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderProcessor orderProcessor;

        public CheckoutController(IAddressRepository addressRepository, IPaymentTypesRepository paymentTypesRepository,
            IMapper mapper, ApplicationUserManager applicationUserManager, IProductRepository productRepository, IOrderProcessor orderProcessor)
            :base(applicationUserManager)
        {
            this.addressRepository = addressRepository;
            this.paymentTypesRepository = paymentTypesRepository;
            this.mapper = mapper;
            this.orderProcessor = orderProcessor;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Cart cart)
        {
            string userId = await GetCurrentUserIdAsync();
            Address address = addressRepository.GetUserAddress(userId);

            CheckoutViewModel checkoutViewModel = new CheckoutViewModel();
            checkoutViewModel.AddressData = mapper.Map<AddressDataViewModel>(address);
            checkoutViewModel.Cart = cart;
            checkoutViewModel.PaymentTypes = paymentTypesRepository.GetAllEnabled().ToList();

            return View(checkoutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckoutViewModel checkoutViewModel)
        {
            if (ModelState.IsValid)
            {
                List<ProductOrder> productOrders = new List<ProductOrder>();
                checkoutViewModel.Cart.CartMembers.ForEach(cm =>
                {
                    productOrders.Add(new ProductOrder { Product = productRepository.GetProductById(cm.ProductId), Quantity = cm.Count }
                );
                });

                string userId = await GetCurrentUserIdAsync();
                Order order = new Order(productOrders,
                    checkoutViewModel.Cart.Total, userId);

                await orderProcessor.ProcessAsync(order, $"{Request.Scheme}://{Request.Host}{Request.PathBase}");

                ControllerContext.HttpContext?.Session.Remove(Cart.SessionKey);
                TempData["msg"] = "Your order has been placed! You will receive an email message with details.";
                return RedirectToAction("Index", "Order", null);
            }
            else
                return View(checkoutViewModel);
        }
    }
}