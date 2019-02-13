using ShopTemplate.Enums;

namespace ShopTemplate.Extensions
{
    public static class EnumExtensions
    {
        public static OrderSortingOption GetOpposite(this OrderSortingOption orderSortingOption)
        {
            switch (orderSortingOption)
            {
                case OrderSortingOption.IdDescending:
                    return OrderSortingOption.IdAscending;

                case OrderSortingOption.IdAscending:
                    return OrderSortingOption.IdDescending;

                case OrderSortingOption.DateDescending:
                    return OrderSortingOption.DateAscending;

                case OrderSortingOption.DateAscending:
                    return OrderSortingOption.DateDescending;

                case OrderSortingOption.TotalDescending:
                    return OrderSortingOption.TotalAscending;

                case OrderSortingOption.TotalAscending:
                    return OrderSortingOption.TotalDescending;

                case OrderSortingOption.StateAscending:
                    return OrderSortingOption.StateDescending;

                case OrderSortingOption.StateDescending:
                    return OrderSortingOption.StateAscending;

                default:
                    return OrderSortingOption.None;
            }
        }
    }
}
