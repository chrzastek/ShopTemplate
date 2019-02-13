﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopTemplate.Models;

namespace ShopTemplate.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20190111174736_rateUpgrade")]
    partial class rateUpgrade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuildingNumber");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Sports" },
                        new { Id = 2, Name = "Electronics" },
                        new { Id = 3, Name = "Fashion" },
                        new { Id = 4, Name = "Jewellery" }
                    );
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("State");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new { Id = 1, Description = "Transfer funds via bank transfer. May last up to couple of days.", Enabled = true, Name = "Bank transfer" },
                        new { Id = 2, Description = "Pay with PayPal", Enabled = true, Name = "PayPal" },
                        new { Id = 3, Description = "Provide us token from your bank system", Enabled = true, Name = "Token" },
                        new { Id = 4, Description = "Pay by our own payment system", Enabled = false, Name = "ShopTemplate payment" }
                    );
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.PendingRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PendingRates");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, CategoryId = 4, Description = "Gold beautifull wedding ring", ImagePath = "images/products/productImage_1.png", Name = "Ring", Price = 499m },
                        new { Id = 2, CategoryId = 2, Description = "Newest model of the japan smartphone", ImagePath = "images/products/unavailable.png", Name = "Smartphone", Price = 1499m },
                        new { Id = 3, CategoryId = 3, Description = "Brown leather belt, length 100cm", ImagePath = "images/products/productImage_3.png", Name = "Leather belt", Price = 89m },
                        new { Id = 4, CategoryId = 3, Description = "Dark sunglasses with UV filter", ImagePath = "images/products/productImage_4.png", Name = "Sunglasses", Price = 99m },
                        new { Id = 5, CategoryId = 3, Description = "Digital watch with rubber belt", ImagePath = "images/products/unavailable.png", Name = "Watch", Price = 39m },
                        new { Id = 6, CategoryId = 2, Description = "Xbox one S with 1TB disc space", ImagePath = "images/products/unavailable.png", Name = "Xbox One S", Price = 899m },
                        new { Id = 7, CategoryId = 3, Description = "Trendy woman hat", ImagePath = "images/products/unavailable.png", Name = "White hat", Price = 70m },
                        new { Id = 8, CategoryId = 2, Description = "Wireless optical computer mouse", ImagePath = "images/products/productImage_8.png", Name = "Computer mouse", Price = 89m },
                        new { Id = 9, CategoryId = 1, Description = "Official world championship foot ball", ImagePath = "images/products/productImage_9.png", Name = "Football", Price = 100m },
                        new { Id = 10, CategoryId = 1, Description = "Tennis racket for beginners", ImagePath = "images/products/productImage_10.png", Name = "Tenis racket", Price = 78m },
                        new { Id = 11, CategoryId = 1, Description = "Two pieces woman swimsuit", ImagePath = "images/products/unavailable.png", Name = "Swim suit", Price = 49m },
                        new { Id = 12, CategoryId = 1, Description = "Super-light running shoes", ImagePath = "images/products/productImage_12.png", Name = "Running shoes", Price = 49m },
                        new { Id = 13, CategoryId = 4, Description = "Original silver earings", ImagePath = "images/products/unavailable.png", Name = "Silver earings", Price = 399m }
                    );
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.ProductOrder", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName");

                    b.Property<int>("Rating");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.UserMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Body");

                    b.Property<bool>("Read");

                    b.Property<string>("SenderEmail");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("ShopTemplate.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AddressId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShopTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShopTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShopTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.PendingRate", b =>
                {
                    b.HasOne("ShopTemplate.Domain.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Product", b =>
                {
                    b.HasOne("ShopTemplate.Domain.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.ProductOrder", b =>
                {
                    b.HasOne("ShopTemplate.Domain.Models.Entities.Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopTemplate.Domain.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.Rate", b =>
                {
                    b.HasOne("ShopTemplate.Domain.Models.Entities.Product")
                        .WithMany("Rates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopTemplate.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShopTemplate.Domain.Models.Entities.UserMessage", b =>
                {
                    b.HasOne("ShopTemplate.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("ShopTemplate.Models.ApplicationUser", b =>
                {
                    b.HasOne("ShopTemplate.Domain.Models.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}
