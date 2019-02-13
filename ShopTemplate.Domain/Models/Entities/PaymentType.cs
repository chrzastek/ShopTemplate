﻿namespace ShopTemplate.Domain.Models.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
    }
}
