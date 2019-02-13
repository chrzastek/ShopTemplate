using Microsoft.AspNetCore.Identity;
using ShopTemplate.Domain.Models.Entities;

namespace ShopTemplate.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Address Address { get; set; } 
    }
}
