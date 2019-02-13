using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Abstract.Utils;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShopTemplate.UnitTests
{
    public static class Mocks
    {
        private static IQueryable<PaymentType> GetPaymentTypes()
        {
            return new List<PaymentType>
            {
                new PaymentType { Id = 1, Name = "Bank", Description = "", Enabled = true },
                new PaymentType { Id = 1, Name = "PayPal", Description = "", Enabled = true },
                new PaymentType { Id = 1, Name = "Transfer", Description = "", Enabled = true },
            }.AsQueryable();
        }

        private static List<ApplicationUser> GetApplicationUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser() { Id = "1" },
                new ApplicationUser() { Id = "2" }
            };
        }

        private static Order GetOrder()
        {
            return new Order { Id = 1 };
        }

        private static IQueryable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {
                    Id = 1,
                    Name = "Ring",
                    Category  = new Category() { Name = "Jewellery" },
                    Price = Convert.ToDecimal(499),
                },
                new Product {
                    Id = 2,
                    Name = "Watch",
                    Category  = new Category() { Name = "Fashion" },
                    Price = Convert.ToDecimal(499),
                },
                new Product {
                    Id = 3,
                    Name = "Football",
                    Category  = new Category() { Name = "Sports" },
                    Price = Convert.ToDecimal(499),
                },
                new Product {
                    Id = 4,
                    Name = "Hat",
                    Category  = new Category() { Name = "Fashion" },
                    Price = Convert.ToDecimal(499),
                },
                new Product {
                    Id = 5,
                    Name = "Smartphone",
                    Category  = new Category() { Name = "Electronics" },
                    Price = Convert.ToDecimal(499),
                },
                new Product {
                    Id = 6,
                    Name = "Shoes",
                    Category  = new Category() { Name = "Fashion" },
                    Price = Convert.ToDecimal(499),
                },
            }.AsQueryable();
        }

        public static Product GetProduct()
        {
            return new Product { Id = 1 };
        }

        public static ShopCart.Cart GetCart()
        {
            return new ShopCart.Cart();
        }

        public static IProductRepository GetProductRepository()
        {
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.GetProductById(1)).Returns(GetProduct());
            productRepositoryMock.Setup(r => r.Products).Returns(GetProducts());
            return productRepositoryMock.Object;
        }



        public static IMapper GetMapper()
        {
            return new Mock<IMapper>().Object;
        }

        public static IAddressRepository GetAddressRepository()
        {
            Mock<IAddressRepository> addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(p => p.GetUserAddress("1")).Returns(new Address { Id = "1" });
            return addressRepositoryMock.Object;
        }

        public static IPaymentTypesRepository GetPaymentTypesRepository()
        {
            Mock<IPaymentTypesRepository> paymentsRepositoryMock = new Mock<IPaymentTypesRepository>();
            paymentsRepositoryMock.Setup(p => p.GetAllEnabled()).Returns(GetPaymentTypes());
            return paymentsRepositoryMock.Object;
        }

        public static IOrderProcessor GetOrderProcessor()
        {
            return new Mock<IOrderProcessor>().Object;
        }

        public static ApplicationUserManager GetMockUserManager()
        {
            Mock<IUserStore<ApplicationUser>> store = new Mock<IUserStore<ApplicationUser>>();
            Mock<ApplicationUserManager> appUserManagerMock = new Mock<ApplicationUserManager>(store.Object,
                null, null, null, null, null, null, null, null);
            appUserManagerMock.Object.UserValidators.Add(new UserValidator<ApplicationUser>());
            appUserManagerMock.Object.PasswordValidators.Add(new PasswordValidator<ApplicationUser>());

            appUserManagerMock.Setup(x => x.FindByNameAsync("user")).Returns(Task.FromResult(new ApplicationUser { Email = "email"}));
            appUserManagerMock.Setup(x => x.GetUserIdByNameAsync("user")).Returns(Task.FromResult("1"));
            appUserManagerMock.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
            appUserManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(),
                It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<ApplicationUser, string>((x, y) => GetApplicationUsers().Add(x));
            appUserManagerMock.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

            return appUserManagerMock.Object;
        }

        public static IIdentity GetIdentity()
        {
            Mock<IIdentity> identity = new Mock<IIdentity>();
            identity.Setup(p => p.Name).Returns("user");
            return identity.Object;
        }

        public static void FillController(Controller controller)
        {
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = new Mock<ISession>().Object;
            controller.ControllerContext.HttpContext.User = new System.Security.Claims.ClaimsPrincipal(Mocks.GetIdentity());
            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            controller.Url = new Mock<IUrlHelper>().Object;
            
        }

        public static IUserMessageRepository GetUserMessageRepository()
        {
            return new Mock<IUserMessageRepository>().Object;
        }

        public static IOrderRepository GetOrderRepository()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            mock.Setup(p => p.GetById(1)).Returns(GetOrder());
            return mock.Object;
        }

        public static IRatesRepository GetRatesRepository()
        {
            Mock<IRatesRepository> mock = new Mock<IRatesRepository>();
            mock.Setup(p => p.PendingForUserWithItemExists("1", 1)).Returns(true);
            return mock.Object;
        }
    }
}
