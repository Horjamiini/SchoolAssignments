using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Refrigerator
    {
        private List<Foodstuff>_foodstuff;
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Temperature { get; set; }
        public List<Foodstuff> Foodstuffs { get { return _foodstuff; } }
        public Refrigerator(string model,string manufacturer,int temperature)
        {
            _foodstuff = new List<Foodstuff>();
            Model = model;
            Manufacturer = manufacturer;
            Temperature = temperature;
        }
        public override string ToString()
        {
            return $"{Model} from {Manufacturer} at temeprature {Temperature}°C has these foodstuffs inside:\n";
        }

    }
    public abstract class Foodstuff
    {
        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public Foodstuff(string name,string expirationdate)
        {
            Name = name;
            ExpirationDate = expirationdate;
        }
        public override string ToString()
        {
            return $"{Name} - Expirationdate: {ExpirationDate}";
        }

    }
    public class Meat : Foodstuff
    {
        public string MeatType { get; set; }
        public string Manufacturer { get; set; }
        public Meat(string name, string expirationdate,string type,string manufacturer):base(name, expirationdate)
        {
            MeatType = type;
            Manufacturer = manufacturer;
        }
        public override string ToString()
        {
            return base.ToString() +$"\nType: Meat,{MeatType} - Manufacturer: {Manufacturer}\n";
        }
    }
    public class Dairy : Foodstuff
    {
        public string DairyType { get; set; }
        public string Manufacturer { get; set; }
        public Dairy(string name, string expirationdate, string type, string manufacturer):base(name, expirationdate)
        {
            DairyType = type;
            Manufacturer = manufacturer;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nType: Dairy,{DairyType} - Manufacturer: {Manufacturer}\n";
        }
    }
    public class Vegetable : Foodstuff
    {
        public string Type { get; set; }
        public string OriginCountry { get; set; }

        public Vegetable(string name, string expirationdate,string type,string country):base(name, expirationdate)
        {
            Type = type;
            OriginCountry = country;
        }
        public override string ToString()
        {
            if (OriginCountry == "Finland" || OriginCountry == "finland")
            {
                return base.ToString() + $"\nType: {Type} - Domestic\n";
            }
            else
            {
                return base.ToString() + $"\nType: {Type} - Foreign from: {OriginCountry}\n";
            }
        }
    }

    internal class Program
    {
        static void TestRefrigerator()
        {
            Refrigerator jääkaappi = new Refrigerator("RJKL3000", "Rosenlew", 5);
            jääkaappi.Foodstuffs.Add(new Meat("Kanan fileesuikaleet","30-03-2023","Chicken","Kariniemi"));
            jääkaappi.Foodstuffs.Add(new Meat("Sika-nauta jauheliha", "15-02-2023", "Minced meat", "Snellman"));
            jääkaappi.Foodstuffs.Add(new Dairy("Kevytmaito","24-03-2023","Milk","Kotimaista"));
            jääkaappi.Foodstuffs.Add(new Dairy("Banaani jogurtti", "27-03-2023", "Yogurt", "Valio"));
            jääkaappi.Foodstuffs.Add(new Dairy("Kuohukerma", "20-01-2023", "Whipping cream", "Pirkka"));
            jääkaappi.Foodstuffs.Add(new Vegetable("Cucumber","Non Disclosed","Vegetable","Finland"));
            jääkaappi.Foodstuffs.Add(new Vegetable("Tangerine", "30-04-2023", "Fruit", "Spain"));
            jääkaappi.Foodstuffs.Add(new Vegetable("Beetroot", "Non Disclosed", "Root", "Finland"));

            Console.WriteLine(jääkaappi);
            foreach (var item in jääkaappi.Foodstuffs)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            TestRefrigerator();
        }
    }
}
