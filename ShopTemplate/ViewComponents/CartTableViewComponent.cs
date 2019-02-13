using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.ShopCart;
using System.Threading.Tasks;

namespace ShopTemplate.ViewComponents
{
    [Authorize]
    public class CartTableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Cart cart)
        {
            return await Task.FromResult<IViewComponentResult>(View(cart));
        }
    }
}
