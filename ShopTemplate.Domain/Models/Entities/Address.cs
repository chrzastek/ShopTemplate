using ShopTemplate.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTemplate.Domain.Models.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZipCode { get; set; }
    }
}
