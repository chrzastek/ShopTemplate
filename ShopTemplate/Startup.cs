using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Abstract.Utils;
using ShopTemplate.Domain.Services.Concrete;
using ShopTemplate.Domain.Services.Concrete.Email;
using ShopTemplate.Domain.Services.Concrete.Repos;
using ShopTemplate.Domain.Services.Concrete.User;
using ShopTemplate.Models;
using ShopTemplate.ShopCart;
using ShopTemplate.ViewModels;
using System;

namespace ShopTemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new CartBinderProvider());
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ShopDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });

            //mapper
            services.AddTransient<IMapper>(m => new Mapper(new MapperConfiguration
                (cfg => 
                    {
                        cfg.CreateMap<AddressDataViewModel, Address>().ForMember(p => p.User, opt => opt.Ignore());
                        cfg.CreateMap<Product, ProductToRate>();
                        cfg.CreateMap<ProductToRate, Rate>().BeforeMap((source, dest) => dest.AddedDate = DateTime.Now)
                        .ForMember(p => p.Id, opt => opt.Ignore());
                    })));

            //utils
            services.AddTransient<ApplicationUserManager>();
            services.AddTransient<IOrderProcessor, OrderProcessor>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            
            //email
            services.AddSingleton<EmailerConfiguration>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmailBodyBuilder, EmailBodyBuilder>();
            services.AddTransient<IEmailEngine, EmailEngine>();

            //repos
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IPaymentTypesRepository, PaymentTypesRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserMessageRepository, UserMessageRepository>();
            services.AddTransient<IRatesRepository, RatesRepository>();

            //googleAuth
            services.AddAuthentication().AddGoogle("google", options =>
            {
                options.ClientId = "955241370360-ucfpvd3fkasl0m0fqs0n9cper9icst6v.apps.googleusercontent.com";
                options.ClientSecret = "NebF2XrfLf-QfmzDm6igSR2G";
                options.SignInScheme = IdentityConstants.ExternalScheme;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
