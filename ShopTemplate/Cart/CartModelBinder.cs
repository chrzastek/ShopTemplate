using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ShopTemplate.ShopCart
{
    public class CartModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            Cart cart;
            string sessionCartKey = string.Empty;

            if(bindingContext.HttpContext.Session != null)
                sessionCartKey = bindingContext.HttpContext.Session.GetString(Cart.SessionKey);

            if(string.IsNullOrEmpty(sessionCartKey))
            {
                cart = new Cart();
                bindingContext.HttpContext.Session.SetString(Cart.SessionKey, JsonConvert.SerializeObject(cart));
            }
            else
                cart = JsonConvert.DeserializeObject<Cart>(sessionCartKey);
           
            bindingContext.Result = ModelBindingResult.Success(cart);
            return Task.CompletedTask;
        }
    }
}
