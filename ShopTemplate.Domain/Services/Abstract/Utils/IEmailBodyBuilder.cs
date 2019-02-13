using ShopTemplate.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace ShopTemplate.Domain.Services.Abstract
{
    public interface IEmailBodyBuilder
    {
        Tuple<string, string> BuildPasswordResetMessage(string passwordResetLink);
        Tuple<string, string> BuildEmailConfirmationLinkMessage(string emailConfirmationLink);
        Tuple<string, string> BuildOrderPlacedMessage(Order order, List<Product> products, string baseUrl);
    }
}
