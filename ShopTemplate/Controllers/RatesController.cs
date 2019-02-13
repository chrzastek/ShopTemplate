using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.ViewModels;

namespace ShopTemplate.Controllers
{
    [Authorize]
    public class RatesController : ApplicationController
    {
        private readonly IRatesRepository ratesRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public RatesController(IMapper mapper, IRatesRepository ratesRepository,
            IProductRepository productRepository, ApplicationUserManager applicationUserManager)
            :base(applicationUserManager)
        {
            this.productRepository = productRepository;
            this.ratesRepository = ratesRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RatesViewModel ratesViewModel = new RatesViewModel();

            string userId = await GetCurrentUserIdAsync();
            List<PendingRate> userPendingRates = ratesRepository.GetPendingsForUser(userId).ToList();

            foreach (PendingRate pendingRate in userPendingRates)
            {
                ratesViewModel.ProductsToRate.Add(new ProductToRate
                { Id = pendingRate.Product.Id, Name = pendingRate.Product.Name, DateOfPurchase = pendingRate.PurchaseDate });
            }

            ratesViewModel.GivenRates = ratesRepository
                .GetRatesGivenByUser(userId)
                .OrderByDescending(r => r.AddedDate)
                .ToList();

            return View(ratesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Rate(int productId)
        {
            string userId = await GetCurrentUserIdAsync();

            if (ratesRepository.PendingForUserWithItemExists(userId, productId))
            {
                Product product = productRepository.GetProductById(productId);
                ProductToRate productToRate = mapper.Map<ProductToRate>(product);
                return View(productToRate);
            }
            else
                return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Rate(ProductToRate productToRate)
        {
            if(ModelState.IsValid)
            {
                Rate rate = mapper.Map<Rate>(productToRate);
                rate.User.Id = await GetCurrentUserIdAsync();
                rate.Product = productRepository.GetProductById(productToRate.Id);

                await ratesRepository.AddAsync(rate);
                await ratesRepository.RemovePendingAsync(rate.User.Id, rate.Product.Id);

                TempData["msg"] = "Your rating has been added!";
                return RedirectToAction("ProductInfo", "Home", new { productId = productToRate.Id });
            }
            else
                return View(productToRate);
        }
    }
}