using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Models;
using System.Threading.Tasks;

namespace ShopTemplate.Controllers
{
    public class ApplicationController : Controller
    {
        protected readonly ApplicationUserManager applicationUserManager;

        public ApplicationController(ApplicationUserManager applicationUserManager)
        {
            this.applicationUserManager = applicationUserManager;
        }

        public virtual async Task<string> GetCurrentUserIdAsync()
        {
            string userName = HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
                return null;
            else
                return await applicationUserManager.GetUserIdByNameAsync(userName);
        }

        public virtual async Task<ApplicationUser> GetCurrentUser()
        {
            string userName = HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
                return null;
            else
                return await applicationUserManager.FindByNameAsync(userName);
        }
    }
}
