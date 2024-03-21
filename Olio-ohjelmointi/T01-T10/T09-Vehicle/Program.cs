using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Vehicle
    {
        //fields
        //properites
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tires { get; set; }
        //constructors
        //methods
        public string ShowInfo()
        {
            return $"Brand: {Brand}\n Model: {Model}";
        }
        public override string ToString()
        {
            return $"Brand: {Brand}\n Model: {Model}\n Speed: {Speed}\n Tires:{Tires}";
        }
    }
    internal class Program
    {
        static void TestVehicles()
        {
            Vehicle car = new Vehicle() { Brand = "Toyota", Model = "Corolla", Speed = 120, Tires = 4 };
            Vehicle bicycle = new Vehicle()
            {
                Brand = "Tunturi",
                Model = "Havu",
                Speed = 20,
                Tires = 2
            };

            car.Brand = "Renault";
            car.Model = "Clio";

            bicycle.Speed = 10;

            Console.WriteLine($"{car.ShowInfo()}");
            Console.WriteLine($"{bicycle.ToString()}");
        }
        static void Main(string[] args)
        {
            TestVehicles();
        }
    }
}
