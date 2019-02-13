using System.Linq;

namespace ShopTemplate.Domain.Models.Entities
{
    public partial class Product
    {
        public double ComputeAverageRating()
        {
            if (Rates.Count > 0)
                return Rates.Sum(r => r.Rating) / Rates.Count;
            else
                return 0;
        }
    }
}