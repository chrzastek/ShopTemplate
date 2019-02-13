using ShopTemplate.ShopCart;

namespace ShopTemplate.ViewModels
{
    public class CartSummaryViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
