using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Enums;
using ShopTemplate.Extensions;
using ShopTemplate.Helpers;
using ShopTemplate.ViewModels;
using System.Threading.Tasks;

namespace ShopTemplate.Controllers
{
    [Authorize]
    public class OrderController : ApplicationController
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository, ApplicationUserManager applicationUserManager)
            :base(applicationUserManager)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(OrderSortingType orderSortingType, OrderSortingOption previousSortingOption)
        {
            OrderSortingOption newSortingOption = OrdersSortingLogic.GetNewSortingOption(orderSortingType, previousSortingOption);

            OrdersListViewModel ordersListViewModel = new OrdersListViewModel();
            ordersListViewModel.PreviousSortingOption = newSortingOption;

            string userId = await GetCurrentUserIdAsync();
            ordersListViewModel.Orders = orderRepository
                .GetUserOrders(userId)
                .SortBy(newSortingOption);

            return View(ordersListViewModel);
        }

        [HttpGet]
        public IActionResult Details(int orderId)
        {
            Order order = orderRepository.GetById(orderId);
            if (order != null)
                return View(order);
            else
                return View("Error");
        }
    }
}