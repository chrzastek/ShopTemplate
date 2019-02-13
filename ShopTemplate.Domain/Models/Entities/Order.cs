using ShopTemplate.Domain.Enums;
using ShopTemplate.Models;
using System;
using System.Collections.Generic;

namespace ShopTemplate.Domain.Models.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public OrderState State { get; set; }
        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
