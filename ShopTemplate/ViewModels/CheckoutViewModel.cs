using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.ShopCart;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopTemplate.ViewModels
{
    public class CheckoutViewModel
    {
        public AddressDataViewModel AddressData { get; set; }
        public List<PaymentType> PaymentTypes { get; set; } = new List<PaymentType>();
        public Cart Cart { get; set; }

        [Required]
        [Display(Name = "Payment method")]
        public string SelectedPayment { get; set; }
    }
}
