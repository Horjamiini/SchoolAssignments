using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Tire
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TireSize { get; set; }
        public Tire(string manufacturer,string model, string tiresize)
        {
            Manufacturer = manufacturer;
            Model = model;
            TireSize = tiresize;
        }
        public override string ToString()
        {
            return $"-Name: {Manufacturer}, Model:{Model}, TireSize:{TireSize}";
        }
    }
    public class Vehicle
    {
        private List<Tire> _tires;
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public List<Tire> Tires { get { return _tires; } }
        public Vehicle(string name,string model, string type)
        {
            Name = name;
            Model = model;
            Type = type;
            if (type == "car" || type == "Car")
            {
                _tires = new List<Tire>(4);
            }
            else { _tires = new List<Tire>(2); }
        }
        public override string ToString()
        {
            return $"\nVehicle Name: {Name}\nModel: {Model}\nTires:";
        }
    }
    internal class Program
    {
        static void TestVehicles()
        {
            Vehicle car = new Vehicle("Audi", "A6", "Car");
            Console.WriteLine($"Created a new vehicle {car.Name}, model {car.Model}");
            for (int i = 0;i < car.Tires.Capacity;i++)
            {
                Tire cartire = new Tire("Pirelli", "Cinturato P7", "205/55R16");
                car.Tires.Add(cartire);
                Console.WriteLine($"Tire {cartire.Manufacturer} added to vehicle {car.Name}");
            }
            Console.WriteLine(car);
            foreach (var item in car.Tires)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n");

            Vehicle bike = new Vehicle("Honda", "CBR 1000 RR Fireblade", "bike");
            Console.WriteLine($"Created a new vehicle {bike.Name} model {bike.Model}");

            Tire biketire1 = new Tire("Pirelli", "Diablo Rosso IV", "120ZR17");
            Tire biketire2 = new Tire("Pirelli", "Diablo Rosso IV", "190ZR17");
            bike.Tires.Add(biketire1);
            bike.Tires.Add(biketire2);
            Console.WriteLine($"Name {biketire1.Manufacturer} added to vehicle {bike.Name}");
            Console.WriteLine($"Name {biketire2.Manufacturer} added to vehicle {bike.Name}");
            Console.WriteLine(bike.ToString());
            foreach (var item in bike.Tires)
            {
                Console.WriteLine(item.ToString());
            }

        }
        static void Main(string[] args)
        {
            TestVehicles();
        }
    }
}
