using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public abstract class Mammal
    {
        public int Age { get; set; }
        public abstract string Move();
    }
    public class Human : Mammal
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Grow (){ return Age += 1; }
        public override string Move()
        {
            return "Moving";
        }
    }
    public class Adult : Human
    {
        public string Car { get; set; }
        public override string Move()
        {
            return "Walking";
        }
    }
    public class Baby : Human
    {
        public string Diaper { get; set; }
        public override string Move()
        {
            return "Crawling";
        }
    }
    internal class Program
    {
        static void TestAdults()
        {
            Adult aikuinen1 = new Adult()
            {
                Name = "Heikki",
                Age = 50,
                Height = 185,
                Weight = 85,
                Car = "Audi"
            };
            Adult aikuinen2 = new Adult()
            {
                Name = "Seppo",
                Age = 21,
                Height = 165,
                Weight = 60,
                Car = "Toyota"
            };

            Console.WriteLine($"Name: {aikuinen1.Name}, Age:{aikuinen1.Age}");
            aikuinen1.Grow();
            aikuinen1.Grow();
            aikuinen1.Grow();
            Console.WriteLine("Growing...");
            Console.WriteLine($"Name:{aikuinen1.Name}, Age:{aikuinen1.Age}\n");
            Console.WriteLine($"Name:{aikuinen2.Name}, Age:{aikuinen2.Age}, Height:{aikuinen2.Height}cm, Weight:{aikuinen2.Weight}Kg, Car:{aikuinen2.Car} -> {aikuinen2.Move()}\n");

        }
        static void TestBabies()
        {
            Baby vauva1 = new Baby()
            {
                Name = "Kaarina",
                Age = 2,
                Height = 80,
                Weight = 7,
                Diaper = "Clean"
            };
            Baby vauva2 = new Baby()
            {
                Name = "Ismo",
                Age = 1,
                Height = 50,
                Weight = 3,
                Diaper = "Dirty"
            };

            Console.WriteLine($"Name:{vauva1.Name}, Age:{vauva1.Age}");
            vauva1.Grow();
            vauva1.Grow();
            vauva1.Grow();
            Console.WriteLine("Growing...");
            Console.WriteLine($"{vauva1.Name}, Age:{vauva1.Age}\n");
           Console.WriteLine($"Name:{vauva2.Name}, Age:{vauva2.Age}, Height:{vauva2.Height}cm, Weight:{vauva2.Weight}Kg, Diaper:{vauva2.Diaper} -> {vauva2.Move()}\n");
        }
        static void Main(string[] args)
        {
            TestAdults();
            TestBabies();
        }
    }
}
