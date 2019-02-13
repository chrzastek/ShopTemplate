using System.ComponentModel.DataAnnotations;

namespace ShopTemplate.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
