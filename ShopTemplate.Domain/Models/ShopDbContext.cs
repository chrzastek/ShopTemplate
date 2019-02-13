using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopTemplate.Domain.Models.Entities;
using System;

namespace ShopTemplate.Models
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) {  }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<PendingRate> PendingRates { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductOrder>().HasKey("OrderId", "ProductId");

            #region seed
            builder.Entity<PaymentType>().HasData(
                new PaymentType() { Id = 1, Name = "Bank transfer", Description = "Transfer funds via bank transfer. May last up to couple of days.", Enabled = true },
                new PaymentType() { Id = 2, Name = "PayPal", Description = "Pay with PayPal", Enabled = true},
                new PaymentType() { Id = 3, Name = "Token", Description = "Provide us token from your bank system", Enabled = true },
                new PaymentType() { Id = 4, Name = "ShopTemplate payment", Description = "Pay by our own payment system", Enabled = false }
                );

            builder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Sports" }, 
                new Category() { Id = 2, Name = "Electronics" },
                new Category() { Id = 3, Name = "Fashion" },
                new Category() { Id = 4, Name = "Jewellery" });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 1,
                    Name = "Ring",
                    Description = "Gold beautifull wedding ring",
                    Price = Convert.ToDecimal(499),
                    CategoryId = 4,
                    ImagePath = "images/products/productImage_1.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "Newest model of the japan smartphone",
                    Price = Convert.ToDecimal(1499),
                    CategoryId = 2,
                    ImagePath = "images/products/unavailable.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 3,
                    Name = "Leather belt",
                    Description = "Brown leather belt, length 100cm",
                    Price = Convert.ToDecimal(89),
                    CategoryId = 3,
                    ImagePath = "images/products/productImage_3.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 4,
                    Name = "Sunglasses",
                    Description = "Dark sunglasses with UV filter",
                    Price = Convert.ToDecimal(99),
                    CategoryId = 3,
                    ImagePath = "images/products/productImage_4.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 5,
                    Name = "Watch",
                    Description = "Digital watch with rubber belt",
                    Price = Convert.ToDecimal(39),
                    CategoryId = 3,
                    ImagePath = "images/products/unavailable.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 6,
                    Name = "Xbox One S",
                    Description = "Xbox one S with 1TB disc space",
                    Price = Convert.ToDecimal(899),
                    CategoryId = 2,
                    ImagePath = "images/products/unavailable.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 7,
                    Name = "White hat",
                    Description = "Trendy woman hat",
                    Price = Convert.ToDecimal(70),
                    CategoryId = 3,
                    ImagePath = "images/products/unavailable.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 8,
                    Name = "Computer mouse",
                    Description = "Wireless optical computer mouse",
                    Price = Convert.ToDecimal(89),
                    CategoryId = 2,
                    ImagePath = "images/products/productImage_8.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 9,
                    Name = "Football",
                    Description = "Official world championship foot ball",
                    Price = Convert.ToDecimal(100),
                    CategoryId = 1,
                    ImagePath = "images/products/productImage_9.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 10,
                    Name = "Tenis racket",
                    Description = "Tennis racket for beginners",
                    Price = Convert.ToDecimal(78),
                    CategoryId = 1,
                    ImagePath = "images/products/productImage_10.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 11,
                    Name = "Swim suit",
                    Description = "Two pieces woman swimsuit",
                    Price = Convert.ToDecimal(49),
                    CategoryId = 1,
                    ImagePath = "images/products/unavailable.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 12,
                    Name = "Running shoes",
                    Description = "Super-light running shoes",
                    Price = Convert.ToDecimal(49),
                    CategoryId = 1,
                    ImagePath = "images/products/productImage_12.png"
                });

            builder.Entity<Product>()
                .HasData(new
                {
                    Id = 13,
                    Name = "Silver earings",
                    Description = "Original silver earings",
                    Price = Convert.ToDecimal(399),
                    CategoryId = 4,
                    ImagePath = "images/products/unavailable.png"
                });
            #endregion
        }
    }
}