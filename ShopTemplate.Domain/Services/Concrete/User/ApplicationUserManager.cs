using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShopTemplate.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete.User
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            :base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) { }

        public virtual async Task<string> GetUserIdByNameAsync(string userName)
        {
            ApplicationUser applicationUser = await GetUserByNameAsync(userName);
            return applicationUser == null ? null : applicationUser.Id;
        }

        public virtual async Task<string> GetUserEmailByIdAsync(string userId)
        {
            ApplicationUser applicationUser = await FindByIdAsync(userId);
            return applicationUser == null ? null : applicationUser.Email;
        }

        protected virtual async Task<ApplicationUser> GetUserByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;
            else
            {
                ApplicationUser applicationUser = await FindByNameAsync(userName);
                if (applicationUser != null)
                    return applicationUser;
                else
                    return null;
            }
        }
    }
}
