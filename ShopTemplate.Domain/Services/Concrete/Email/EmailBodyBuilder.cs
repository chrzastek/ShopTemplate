using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTemplate.Domain.Services.Concrete.Email
{
    public class EmailBodyBuilder : IEmailBodyBuilder
    {
        public Tuple<string, string> BuildEmailConfirmationLinkMessage(string emailConfirmationLink)
        {
            string message = $"Welcome in ShopTemplate! <br />" +
                $" In order to activate your account, please click <a href=\"{emailConfirmationLink}\">HERE</a>.";

            string emailContent = string.Format(EmailTemplates.EmailBodyHtmlTemplate, message, EmailTemplates.Footer);
            return Tuple.Create("Welcome in ShopTemplate!", emailContent);
        }

        public Tuple<string, string> BuildPasswordResetMessage(string passwordResetLink)
        {
            string message = $"We've received a password reseting request for ShopTemplate account. " +
                $"<br /> Click <a href=\"{passwordResetLink}\">HERE</a> to reset your password. <br />" +
                $"If you did not make such a request, please ignore this message. <br />";

            string emailContent = string.Format(EmailTemplates.EmailBodyHtmlTemplate, message, EmailTemplates.Footer);
            return Tuple.Create("Password reseting", emailContent);
        }

        public Tuple<string, string> BuildOrderPlacedMessage(Order order, List<Product> products, string baseUrl)
        {
            StringBuilder message = new StringBuilder();

            message.Append("Congratulations! You had successfully placed your order in ShopTemplate! <br /><br />");
            message.Append("Order Summary: <br />");
            
            for (int i = 0; i < order.ProductOrders.Count; i++)
            {
                Product product = order.ProductOrders[i].Product;
                string listNumber = (i + 1).ToString();
                message.Append(listNumber);
                message.Append(". ");
                message.Append($"<a href=\"{baseUrl}/Home/ProductInfo?productId={product.Id}\">{product.Name}</a>");
                message.Append(", ");
                message.Append(product.Price.ToString("c"));
                message.Append(". <br />");
            }
            message.Append("<br />");
            message.Append($"Total: {order.Total}");
            message.Append($"Check details of your order <a href=\"{baseUrl}/Order/Details?orderId={order.Id}\">here</a>");

            string emailContent = string.Format(EmailTemplates.EmailBodyHtmlTemplate, message, EmailTemplates.Footer);
            return Tuple.Create("New Order!", emailContent);
        }
    }

    public static class EmailTemplates
    {
        public static string EmailBodyHtmlTemplate = 
            "<!DOCTYPE html><html><head><title>Title</title></head><body><h1>Hello!</h1><br /><p>{0}</p><br /><p>{1}</p></body></html>";

        public static string Footer = "Best Regards, <br /> ShopTemplate team.";
    }
}
