using ShopTemplate.Domain.Enums;
using ShopTemplate.Models;
using System;
using System.Collections.Generic;

namespace ShopTemplate.Domain.Models.Entities
{
    public partial class Order
    {
        public Order() { }

        public Order(List<ProductOrder> productOrders, decimal total, string userId)
        {
            Date = DateTime.Now;
            Total = total;
            State = OrderState.Processing;
            ProductOrders = productOrders;
            User = new ApplicationUser();
            User.Id = userId;
        }
    }
}
