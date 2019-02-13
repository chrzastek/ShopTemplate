using ShopTemplate.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopTemplate.ViewModels
{
    public class RatesViewModel
    {
        public List<ProductToRate> ProductsToRate { get; set; } = new List<ProductToRate>();
        public List<Rate> GivenRates { get; set; } = new List<Rate>();
    }

    public class ProductToRate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "text rate")]
        [StringLength(480, ErrorMessage = "text rate has to be shorter than 480 characters!")]
        public string Text { get; set; }

        [Required]
        public int Rating { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
