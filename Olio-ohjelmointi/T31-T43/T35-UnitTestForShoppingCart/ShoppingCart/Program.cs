using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class ShoppingCart
    {
        private List<Product> _products;
        public List<Product> Products { get { return _products; } }
        public ShoppingCart()
        {
            _products = new List<Product>();
        }
        public int CountProducts()
        {
            return _products.Count;
        }
    }
    internal class Program
    {
        static void TestShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Products.Add(new Product() { Name = "Milk", Price = 2.99M });
            cart.Products.Add(new Product() { Name = "Eggs", Price = 4.99M });
            cart.Products.Add(new Product() { Name = "Cheese", Price = 5.99M });

            Console.WriteLine("Products in shopping cart:");
            foreach (var item in cart.Products)
            {
                Console.WriteLine($"Product: {item.Name} {item.Price}e");
            }
            Console.WriteLine($"There are {cart.CountProducts()} products in the shopping cart.");


        }
        static void Main(string[] args)
        {
            TestShoppingCart();
        }
    }
}