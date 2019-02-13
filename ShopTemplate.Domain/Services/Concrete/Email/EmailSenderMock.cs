using Microsoft.AspNetCore.Identity.UI.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.Email
{
    public class EmailSenderMock : IEmailSender
    {
        public async Task SendEmailAsync(string emailAddress, string title, string message)
        {
            string filePath = @"C:\email.txt";
            List<string> content = new List<string>() { emailAddress, title, message };
            await File.WriteAllLinesAsync(filePath, content);
        }
    }
}
