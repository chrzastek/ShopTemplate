using System.Collections.Generic;
using System.Linq;

namespace ShopTemplate.ShopCart
{
    public class CartMembers : List<CartMember>
    {
        public CartMember GetMemberWithId(int productId)
        {
            return this.FirstOrDefault(m => m.ProductId == productId);
        }

        public void RemoveById(int productId)
        {
            CartMember cartMember = GetMemberWithId(productId);

            if (cartMember != null)
            {
                if (cartMember.Count == 1)
                    Remove(cartMember);
                else
                    cartMember.Count -= 1;
            }
        }

        public decimal Total
        {
            get { return this.Sum(m => m.ProductPrice * m.Count); }
        }

        public int ItemsCount
        {
            get { return this.Sum(m => m.Count); }
        }
    }
}
