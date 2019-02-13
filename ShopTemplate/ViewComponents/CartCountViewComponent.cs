using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShopTemplate.ShopCart;
using System.Threading.Tasks;

namespace ShopTemplate.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int cartCount = 0;
            byte[] cart = new byte[20];
            bool cartExists = HttpContext.Session.TryGetValue(Cart.SessionKey, out cart);

            if(cartExists)
            {
                string cartRawJson = System.Text.Encoding.UTF8.GetString(cart);
                JObject cartJsonObject = JObject.Parse(cartRawJson);
                cartCount = cartJsonObject["Count"].Value<int>();
            }

            return await Task.FromResult<IViewComponentResult>(View(cartCount));
        }
    }
}
