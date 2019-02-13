using ShopTemplate.Domain.Models.Entities;
using System.Linq;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
    }
}
