using ShopTemplate.Domain.Services.Abstract.Utils;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Email
{
    public class EmailEngine : IEmailEngine
    {
        private readonly EmailerConfiguration configuration;

        public EmailEngine(EmailerConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendAsync(string email, string subject, string htmlMessage)
        {
            MailAddress fromAddress = new MailAddress(configuration.AccountName, configuration.AccountDisplayName);
            MailAddress toAddress = new MailAddress(email);

            SmtpClient smtp = new SmtpClient
            {
                Host = configuration.ServerName,
                Port = configuration.ServerPort,
                EnableSsl = configuration.UseSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, configuration.Password)
            };

            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = htmlMessage;

            await Task.Factory.StartNew(() => smtp.SendAsync(message, null));
        }
    }
}
