using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SHAA3209;

namespace SHAA3209
{

    [TestClass]
    public class UnitTestShoppingCart
    {
        [TestMethod]
        public void TestFor0Products()
        {
            // Arrange
            int expectedcount = 0;
            // Act
            ShoppingCart cart = new ShoppingCart();
            // Assert
            int actualcount = cart.CountProducts();
            Assert.AreEqual(expectedcount, actualcount);
        }
        [TestMethod]
        public void TestFor1Products()
        {
            // Arrange
            int expectedcount = 1;
            // Act
            ShoppingCart cart = new ShoppingCart();
            cart.Products.Add(new Product { Name="Milk",Price=2.99M});
            // Assert
            int actualcount = cart.CountProducts();
            Assert.AreEqual(expectedcount, actualcount);
        }
        [TestMethod]
        public void TestFor2Products()
        {
            // Arrange
            int expectedcount = 2;
            // Act
            ShoppingCart cart = new ShoppingCart();
            cart.Products.Add(new Product { Name = "Milk", Price = 2.99M });
            cart.Products.Add(new Product { Name = "Bread", Price = 1.99M });
            // Assert
            int actualcount = cart.CountProducts();
            Assert.AreEqual(expectedcount, actualcount);
        }
        [TestMethod]
        public void TestFor5Products()
        {
            // Arrange
            int expectedcount = 5;
            // Act
            ShoppingCart cart = new ShoppingCart();
            cart.Products.Add(new Product { Name = "Milk", Price = 2.99M });
            cart.Products.Add(new Product { Name = "Bread", Price = 1.39M });
            cart.Products.Add(new Product { Name = "Beer", Price = 0.99M });
            cart.Products.Add(new Product { Name = "Ham", Price = 1.59M });
            cart.Products.Add(new Product { Name = "Chicken", Price = 10.19M });
            // Assert
            int actualcount = cart.CountProducts();
            Assert.AreEqual(expectedcount, actualcount);
        }
    }
}
