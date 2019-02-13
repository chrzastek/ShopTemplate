using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopTemplate.Domain.Models.Entities;

namespace ShopTemplate.ShopCart
{
    [ModelBinder(BinderType = typeof(CartModelBinder))]
    public class Cart
    {
        [JsonProperty]
        private CartMembers members = new CartMembers();

        public static string SessionKey { get; } = "cart";

        public void Add(Product product)
        {
            CartMember cartMember = members.GetMemberWithId(product.Id);

            if (cartMember != null)
                cartMember.Count += 1;
            else
            {
                members.Add(new CartMember()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Count = 1
                });
            }
        }

        public void Remove(int productId)
        {
            members.RemoveById(productId);
        }

        [JsonIgnore]
        public CartMembers CartMembers
        {
            get { return members; }
        }

        public decimal Total
        {
            get { return members.Total; }
        }
        
        public int Count
        {
            get { return members.ItemsCount; }
        }

        public void Clear()
        {
            members.Clear();
        }
    }
}
