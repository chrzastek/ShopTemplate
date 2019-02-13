using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.ShopCart;
using ShopTemplate.ViewModels;

namespace ShopTemplate.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly string cartSummaryViewName = "CartSummary";
        private readonly IProductRepository productRepository;

        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult Add(int productId, Cart cart, string returnUrl)
        {
            Product product = productRepository.GetProductById(productId);

            if (product != null)
            {
                cart.Add(product);
                HttpContext?.Session.SetString(Cart.SessionKey, JsonConvert.SerializeObject(cart));
                return RedirectToAction(cartSummaryViewName, new { returnUrl });
            }
            else
                return View("Error");
        }

        [HttpPost]
        public IActionResult Remove(int productId, Cart cart)
        {
            Product product = productRepository.GetProductById(productId);

            if (product != null)
            {
                cart.Remove(productId);
                HttpContext?.Session.SetString(Cart.SessionKey, JsonConvert.SerializeObject(cart));
                return RedirectToAction(cartSummaryViewName);
            }
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult CartSummary(Cart cart, string returnUrl)
        {
            return View(new CartSummaryViewModel() { Cart = cart, ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Clear(Cart cart)
        {
            cart.Clear();
            HttpContext?.Session.SetString(Cart.SessionKey, JsonConvert.SerializeObject(cart));
            return RedirectToAction(cartSummaryViewName);
        }
    }
}