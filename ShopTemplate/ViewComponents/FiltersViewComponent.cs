using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopTemplate.Enums;
using ShopTemplate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTemplate.ViewComponents
{
    public class FiltersViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string itemsPerPage)
        {
            FilterViewModel filterViewModel = new FilterViewModel()
            {
                ItemPerPageRanges = new List<SelectListItem>
                {
                    new SelectListItem { Text = "4", Value = "4" },
                    new SelectListItem { Text = "8", Value = "8" },
                    new SelectListItem { Text = "12", Value = "12"  },
                    new SelectListItem { Text = "18", Value = "18"  },
                },

                SortyByOptions = Enum.GetNames(typeof(ProductSortingOption)).Select(name => new SelectListItem()
                {
                    Text = name,
                    Value = name
                }),

                SelectedItemPerPage = itemsPerPage
            };

            return await Task.FromResult<IViewComponentResult>(View(filterViewModel));
        }
    }
}
