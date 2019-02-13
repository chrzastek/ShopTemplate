using System.ComponentModel;

namespace ShopTemplate.ViewModels
{
    public class AccountDataViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("Email confirmed")]
        public bool EmailConfirmed { get; set; }
    }
}
