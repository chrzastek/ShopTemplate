using ShopTemplate.Enums;
using ShopTemplate.Extensions;

namespace ShopTemplate.Helpers
{
    public static class OrdersSortingLogic
    {
        //TODO: refactor! maybe replace with state pattern
        public static OrderSortingOption GetNewSortingOption(OrderSortingType orderSortingType, OrderSortingOption previousSortingOption)
        {
            OrderSortingOption newSortingOption = OrderSortingOption.None;

            if (orderSortingType != OrderSortingType.None && previousSortingOption != OrderSortingOption.None)
            {
                switch (orderSortingType)
                {
                    case OrderSortingType.Id:
                        if (previousSortingOption == OrderSortingOption.IdAscending || previousSortingOption == OrderSortingOption.IdDescending)
                            newSortingOption = previousSortingOption.GetOpposite();
                        break;

                    default:
                    case OrderSortingType.Date:
                        if (previousSortingOption == OrderSortingOption.DateAscending || previousSortingOption == OrderSortingOption.DateDescending)
                            newSortingOption = previousSortingOption.GetOpposite();
                        break;

                    case OrderSortingType.Total:
                        if (previousSortingOption == OrderSortingOption.TotalAscending || previousSortingOption == OrderSortingOption.TotalDescending)
                            newSortingOption = previousSortingOption.GetOpposite();
                        break;

                    case OrderSortingType.State:
                        if (previousSortingOption == OrderSortingOption.TotalAscending || previousSortingOption == OrderSortingOption.TotalDescending)
                            newSortingOption = previousSortingOption.GetOpposite();
                        break;
                }

                if (newSortingOption == OrderSortingOption.None)
                    previousSortingOption = OrderSortingOption.None;
            }

            if (previousSortingOption == OrderSortingOption.None && orderSortingType != OrderSortingType.None)
            {
                switch (orderSortingType)
                {
                    case OrderSortingType.Id:
                        newSortingOption = OrderSortingOption.IdDescending;
                        break;
                    default:
                    case OrderSortingType.Date:
                        newSortingOption = OrderSortingOption.DateDescending;
                        break;
                    case OrderSortingType.Total:
                        newSortingOption = OrderSortingOption.TotalDescending;
                        break;
                    case OrderSortingType.State:
                        newSortingOption = OrderSortingOption.StateDescending;
                        break;
                }
            }

            return newSortingOption;
        }
    }
}
