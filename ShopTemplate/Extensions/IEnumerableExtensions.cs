using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ShopTemplate.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IOrderedEnumerable<Product> SortBy(this IEnumerable<Product> products, ProductSortingOption productSortingOption)
        {
            switch (productSortingOption)
            {
                default:
                case ProductSortingOption.AZ:
                    return products.OrderBy(p => p.Name);

                case ProductSortingOption.ZA:
                    return products.OrderByDescending(p => p.Name);

                case ProductSortingOption.PriceAscending:
                    return products.OrderBy(p => p.Price);

                case ProductSortingOption.PriceDescending:
                    return products.OrderByDescending(p => p.Price);
            }
        }

        public static IOrderedEnumerable<Order> SortBy(this IEnumerable<Order> orders, 
            OrderSortingOption sortingOption)
        {
            switch (sortingOption)
            {
                default:
                case OrderSortingOption.None:
                case OrderSortingOption.DateAscending:
                    return orders.OrderBy(o => o.Date);
                case OrderSortingOption.DateDescending:
                        return orders.OrderByDescending(o => o.Date);

                case OrderSortingOption.IdAscending:
                        return orders.OrderBy(o => o.Id);
                case OrderSortingOption.IdDescending:
                        return orders.OrderByDescending(o => o.Id);

                case OrderSortingOption.TotalAscending:
                        return orders.OrderBy(o => o.Total);
                case OrderSortingOption.TotalDescending:
                        return orders.OrderByDescending(o => o.Total);

                case OrderSortingOption.StateAscending:
                        return orders.OrderBy(o => o.State);
                case OrderSortingOption.StateDescending:
                        return orders.OrderByDescending(o => o.State);
            }
        }
    }
}
