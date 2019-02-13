namespace ShopTemplate.Domain.Models.Entities
{
    public class ProductOrder
    {
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
