using NUnit.Framework;
using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.ShopCart;
using System.Linq;

namespace Tests
{
    public class CartTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddNewProduct()
        {
            //arrange
            Cart cart = new Cart();
            Product product = new Product { Id = 1, Name = "Shoes", Price = 20, };

            //act
            cart.Add(product);
            CartMember cartMember = cart.CartMembers.FirstOrDefault();


            //assert
            Assert.AreEqual(1, cart.CartMembers.Count);
            Assert.AreEqual(product.Id, cartMember.ProductId);
            Assert.AreEqual(product.Name, cartMember.ProductName);
            Assert.AreEqual(product.Price, cartMember.ProductPrice);
            Assert.AreEqual(1, cartMember.Count);
        }

        [Test]
        public void AddExistingProduct()
        {
            //arrange
            Cart cart = new Cart();
            Product product = new Product { Id = 1, Name = "Shoes", Price = 20, };

            //act
            cart.Add(product);
            cart.Add(product);
            CartMember cartMember = cart.CartMembers.FirstOrDefault();

            //assert
            Assert.AreEqual(1, cart.CartMembers.Count);
            Assert.AreEqual(product.Id, cartMember.ProductId);
            Assert.AreEqual(product.Name, cartMember.ProductName);
            Assert.AreEqual(product.Price, cartMember.ProductPrice);
            Assert.AreEqual(2, cartMember.Count);
        }

        [Test]
        public void RemoveProduct()
        {
            //arrange
            Cart cart = new Cart();
            Product product = new Product { Id = 1, Name = "Shoes", Price = 20, };
            cart.Add(product);

            //act
            cart.Remove(product.Id);

            Assert.AreEqual(0, cart.CartMembers.Count);
        }

        [Test]
        public void RemoveOneOfTwoProducts()
        {
            //arrange
            Cart cart = new Cart();
            Product product = new Product { Id = 1, Name = "Shoes", Price = 20, };
            cart.Add(product);
            cart.Add(product);

            //act
            cart.Remove(product.Id);
            CartMember cartMember = cart.CartMembers.FirstOrDefault();

            //assert
            Assert.AreEqual(1, cart.CartMembers.Count);
            Assert.AreEqual(product.Id, cartMember.ProductId);
            Assert.AreEqual(product.Name, cartMember.ProductName);
            Assert.AreEqual(product.Price, cartMember.ProductPrice);
            Assert.AreEqual(1, cartMember.Count);
        }

        [Test]
        public void Total()
        {
            //arrange
            Cart cart = new Cart();
            Product product1 = new Product { Id = 1, Name = "Shoes", Price = 20, };
            Product product2 = new Product { Id = 2, Name = "Watch", Price = 100, };
            Product product3 = new Product { Id = 3, Name = "Football", Price = 50, };

            //act
            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product3);

            //assert
            Assert.AreEqual(cart.Total, 170);
        }

        [Test]
        public void Clear()
        {
            //arrange
            Cart cart = new Cart();
            Product product1 = new Product { Id = 1, Name = "Shoes", Price = 20, };
            Product product2 = new Product { Id = 2, Name = "Watch", Price = 100, };
            Product product3 = new Product { Id = 3, Name = "Football", Price = 50, };

            //act
            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product3);
            cart.Clear();

            //assert
            Assert.AreEqual(0, cart.Count);
        }
    }
}