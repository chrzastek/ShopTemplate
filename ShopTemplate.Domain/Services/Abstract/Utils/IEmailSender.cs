using ShopTemplate.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract.Utils
{
    public interface IEmailSender
    {
        Task SendEmailConfirmationLinkAsync(string email, string link);
        Task SendPasswordResetingLinkAsync(string email, string link);
        Task SendOrderPlacedAsync(string email, Order order, List<Product> products, string baseUrl);
    }
}
