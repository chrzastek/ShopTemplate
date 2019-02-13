using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Abstract.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailBodyBuilder emailBodyBuilder;
        private readonly IEmailEngine emailEngine;

        public EmailSender(IEmailBodyBuilder emailBodyBuilder, IEmailEngine emailEngine)
        {
            this.emailEngine = emailEngine;
            this.emailBodyBuilder = emailBodyBuilder;
        }

        public async Task SendEmailConfirmationLinkAsync(string email, string link)
        {
            Tuple<string, string> emailContent = emailBodyBuilder.BuildEmailConfirmationLinkMessage(link);
            await emailEngine.SendAsync(email, emailContent.Item1, emailContent.Item2);
        }

        public async Task SendOrderPlacedAsync(string email, Order order, List<Product> products, string baseUrl)
        {
            Tuple<string, string> emailContent = emailBodyBuilder.BuildOrderPlacedMessage(order, products, baseUrl);
            await emailEngine.SendAsync(email, emailContent.Item1, emailContent.Item2);
        }

        public async Task SendPasswordResetingLinkAsync(string email, string link)
        {
            Tuple<string, string> emailContent = emailBodyBuilder.BuildPasswordResetMessage(link);
            await emailEngine.SendAsync(email, emailContent.Item1, emailContent.Item2);
        }
    }
}
