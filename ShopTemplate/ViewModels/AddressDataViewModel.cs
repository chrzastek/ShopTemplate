using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopTemplate.ViewModels
{
    public class AddressDataViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [DisplayName("Building number")]
        public string BuildingNumber { get; set; }

        [Required]
        [DisplayName("Zip code")]
        public string ZipCode { get; set; }
    }
}
