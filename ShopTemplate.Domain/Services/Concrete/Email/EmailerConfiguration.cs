using Microsoft.Extensions.Configuration;
using System;

namespace ShopTemplate.Domain.Services.Concrete.Email
{
    public class EmailerConfiguration
    {
        private readonly IConfiguration configuration;

        public string AccountName { get; protected set; }
        public string AccountDisplayName { get; set; }
        public bool UseSsl { get; protected set; }
        public string Password { get; protected set; }
        public string ServerName { get; protected set; }
        public int ServerPort { get; protected set; }

        public EmailerConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
            ReadConfiguration();
        }

        protected virtual void ReadConfiguration()
        {
            IConfigurationSection emailerSection = configuration.GetSection("EmailerSettings");
            AccountName = emailerSection["AccountName"];
            UseSsl = Convert.ToBoolean(emailerSection["UseSsl"]);
            Password = emailerSection["Password"];
            ServerName = emailerSection["ServerName"];
            ServerPort = Convert.ToInt32(emailerSection["ServerPort"]);
            AccountDisplayName = emailerSection["AccountDisplayName"];
        }
    }
}
