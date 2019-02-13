using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Abstract.Utils;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Models;
using ShopTemplate.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopTemplate.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationUserManager applicationUserManager;
        private readonly IEmailSender emailSender;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> claimsPrincipalFactory;

        public AccountController(SignInManager<ApplicationUser> signInManager, ApplicationUserManager applicationUserManager, 
            IEmailSender emailSender, IEmailBodyBuilder emailBodyBuilder,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsPrincipalFactory)
        {
            this.signInManager = signInManager;
            this.applicationUserManager = applicationUserManager;
            this.emailSender = emailSender;
            this.claimsPrincipalFactory = claimsPrincipalFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await applicationUserManager.FindByNameAsync(loginViewModel.UserName);

                if (user != null)
                {
                    if(!await applicationUserManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "First you have to confirm your email address!");
                        return View(loginViewModel);
                    }
                   
                    var result = await
                        signInManager.PasswordSignInAsync
                        (user, loginViewModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (Url.IsLocalUrl(loginViewModel.ReturnUrl))
                            return Redirect(loginViewModel.ReturnUrl);
                        else
                            return RedirectToAction("Index", "Home");
                    }
                }
                return View("error");
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    Address = new Address()
                };

                var result = await applicationUserManager.CreateAsync(user, registerViewModel.Password);
                
                if (result.Succeeded)
                {
                    string token = await applicationUserManager.GenerateEmailConfirmationTokenAsync(user);
                    string confirmationEmailLink = Url.Action("ConfirmEmail", "Account",
                            new { token, email = user.Email }, Request.Scheme);

                    await emailSender.SendEmailConfirmationLinkAsync(user.Email, confirmationEmailLink);

                    return View("Message", "Account created successfully! In order to activate account, please click the link from greeting email.");
                }
                else
                    ViewBag.RegisterErrors = result.Errors.Select(e => e.Description);
            }

            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult ForgotPassword(string email)
        {
            ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel { Email = email };
            return View(forgotPasswordViewModel);
        }

        [HttpPost]
        public async  Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await applicationUserManager.FindByEmailAsync(forgotPasswordViewModel.Email);

                if (user != null)
                {
                    string token = await applicationUserManager.GeneratePasswordResetTokenAsync(user);
                    string passwordResetingLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
                    await emailSender.SendPasswordResetingLinkAsync(user.Email, passwordResetingLink);

                    return View("Message", "You should receive password-reseting mail message in a while!");
                }
                else
                {
                    ModelState.AddModelError("", "We do not know this email address.");
                    return View();
                }
            }
            else
                return View(forgotPasswordViewModel);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel passwordResetViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await applicationUserManager.FindByEmailAsync(passwordResetViewModel.Email);

                if (user != null)
                {
                    IdentityResult result = await applicationUserManager.ResetPasswordAsync(user, passwordResetViewModel.Token, passwordResetViewModel.Password);

                    if (!result.Succeeded)
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);

                        return View();
                    }

                    TempData["msg"] = "Your password has been reset! Log-in with new password:";
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError("", "Invalid Request");
                return View(passwordResetViewModel);
            }
            else
                return View(passwordResetViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            ApplicationUser user = await applicationUserManager.FindByEmailAsync(email);

            if (user != null)
            {
                IdentityResult identityResult = await applicationUserManager.ConfirmEmailAsync(user, token);

                if (identityResult.Succeeded)
                {
                    TempData["msg"] = "Your account has been successfully confirmed! You can now log-in.";
                    return RedirectToAction("Login");
                }
                else
                    return View("Error");
            }
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult LoginExternal(string provider, string returnUrl)
        {
            AuthenticationProperties properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoginExternalCallBack", new { returnUrl }),
                Items = { { "scheme", provider} }
            };

            return Challenge(properties, provider);
        }

        [HttpGet]
        public async Task<IActionResult> LoginExternalCallBack()
        {
            var result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

            var externalUserId = result.Principal.FindFirstValue("sub")
                                 ?? result.Principal.FindFirstValue(ClaimTypes.NameIdentifier)
                                 ?? throw new Exception("Cannot find external user id");
            var provider = result.Properties.Items["scheme"];

            var user = await applicationUserManager.FindByLoginAsync(provider, externalUserId);

            if (user == null)
            {
                var email = result.Principal.FindFirstValue("email")
                            ?? result.Principal.FindFirstValue(ClaimTypes.Email);
                if (email != null)
                {
                    user = await applicationUserManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new ApplicationUser { UserName = email, Email = email };
                        await applicationUserManager.CreateAsync(user);
                    }

                    await applicationUserManager.AddLoginAsync(user,
                        new UserLoginInfo(provider, externalUserId, provider));
                }
            }

            if (user == null) return View("Error");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var claimsPrincipal = await claimsPrincipalFactory.CreateAsync(user);
            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);

            return RedirectToAction("Index", "Home");
        }
    }
}