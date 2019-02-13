using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Abstract.Utils
{
    public interface IEmailEngine
    {
        Task SendAsync(string email, string subject, string htmlMessage);
    }
}
