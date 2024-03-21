using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SHAA3209
{
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        //constructors
        public Vehicle() { }
        public Vehicle(string name, string model, int modelyear, string color)
        {
            Name = name;
            Model = model;
            ModelYear = modelyear;
            Color = color;
        }
        //methods
        public override string ToString()
        {
            return $"Name: {Name}\n Model: {Model}\n ModelYear: {ModelYear}\n Color: {Color}";
        }
    }
    public class Bicycle : Vehicle
    {
        private string gearboxmodel;
        public bool HasGearBox { get; set; }
        public string GearBoxName { get; set; }
        public string GearBoxModel
        {
            get { return gearboxmodel; }
            set
            {
                if(HasGearBox)
                {
                    gearboxmodel = GearBoxName;
                }
                else
                {
                    gearboxmodel = "None";
                }
            }
        }
        //constructors
        public Bicycle() { }
        public Bicycle(string name, string model, int modelyear, string color,bool hasgearbox, string gearboxname) : base(name,model,modelyear,color)
        {
            HasGearBox = hasgearbox;
            GearBoxName = gearboxname;
            GearBoxModel = "";
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $" \n HasGearBox: {HasGearBox}\n GearBoxModel: {GearBoxModel}";
        }
    }
    public class Boat : Vehicle
    {
        public string BoatType { get; set; }
        public int Seats { get; set; }
        //constructors
        public Boat(string name, string model, int modelyear, string color, string boattype, int seats) : base(name, model, modelyear, color)
        {
            BoatType = boattype;
            Seats = seats;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $" \n BoatType: {BoatType}\n SeatCount: {Seats}";
        }
    }
    internal class Program
    {
        static void TestBicycles()
        {
            // if the bicycle does not have a gearbox the last variable in the constructor can be left empty or filled with any string
            // it will be defaulted to none if "HasGearBox" value is false
            Bicycle polkupyörä = new Bicycle("Tunturi", "Havu", 2023, "Grey", false, "Shimano");
            Bicycle polkupyörä2 = new Bicycle("Tunturi", "Ralli", 1972, "Yellow", true, "Sturmey Archer");
            Console.WriteLine(polkupyörä.ToString());
            Console.WriteLine(polkupyörä2.ToString());
        }
        static void TestBoats()
        {
            Boat paatti = new Boat("Rainbow","Oasis 4.30 Exp.",2023,"Yellow","Kajak",1);
            Boat paatti2 = new Boat("Terhi", "480 TC", 2021, "White", "Motorboat", 5);
            Console.WriteLine(paatti.ToString());
            Console.WriteLine(paatti2.ToString());
        }
        static void Main(string[] args)
        {
            TestBicycles();
            TestBoats();
        }
    }
}
