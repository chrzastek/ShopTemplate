using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Enums;
using System.Collections.Generic;

namespace ShopTemplate.ViewModels
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public OrderSortingOption PreviousSortingOption { get; set; }
    }
}
