using System.ComponentModel.DataAnnotations;

namespace ShopTemplate.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(480, ErrorMessage = "Message has to be shorter than 480 characters!")]
        [Display(Name = "Your message")]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Your email")]
        public string SenderEmail { get; set; }

        public string ReturnUrl { get; set; }
    }
}
