using Microsoft.AspNetCore.Mvc.Rendering;
using ShopTemplate.Enums;
using System.Collections.Generic;

namespace ShopTemplate.ViewModels
{
    public class FilterViewModel
    {
        public List<SelectListItem> ItemPerPageRanges { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> SortyByOptions { get; set; } = new List<SelectListItem>();
        public string SelectedItemPerPage { get; set; }
        public ProductSortingOption SortingOption { get; set; }
    }
}
