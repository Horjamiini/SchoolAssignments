using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class FishRegister
    {
        private List<Fisher> _fishers;
        public List<Fisher> Fishers { get {return _fishers;} }
        public FishRegister()
        {
            _fishers= new List<Fisher>();
        }
        public string AddFisher(string name,string phone)
        {
            if (_fishers.Any(x=>x.Name.ToLower() == name.ToLower()))
            {
                return $"Fisher {name} is already in the FishREgister";
            }
            else
            {
                _fishers.Add(new Fisher(name, phone));
                return $"A new Fisher added to FishRegister:\n- Fisher: {name}, Phone: {phone}";
            }
        }
        public string AddFish(string name,string species,double length,double weight,string place,string location)
        {
            if (_fishers.Any(x => x.Name.ToLower() == name.ToLower()))
            {
                var findFisher = _fishers.Single(x => x.Name == name);
                findFisher.CatchedFish.Add(new Fish(species, length, weight, place, location,findFisher));
                return $"Fisher : {findFisher.Name} got a new fish:\n- Species: {species} {length.ToString(CultureInfo.InvariantCulture)}cm {weight.ToString(CultureInfo.InvariantCulture)}Kg\n- Place: {place}\n- Location: {location}\n";
            }
            else { return $"Couldn't add a fish to a fishregister! Fisher {name} doesn't exist.\n"; }
        }
        public List<Fish> SortFishes()
        {
            List<Fish> sortedFish = new List<Fish>();
            foreach (var item in _fishers)
            {
                foreach (var fish in item.CatchedFish)
                {
                    sortedFish.Add(fish);
                }
            }
            sortedFish = sortedFish.OrderByDescending(x => x.Weight).ToList();
            return sortedFish;
        }

    }
    public class Fisher
    {
        private List<Fish> _catchedfish;
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Fish> CatchedFish { get { return _catchedfish; } }
        public Fisher()
        {
            _catchedfish = new List<Fish>();
        }
        public Fisher(string name,string phone)
        {
            _catchedfish= new List<Fish>();
            Name = name;
            PhoneNumber = phone;
        }
        public override string ToString()
        {
            return $"Fisher: {Name} - Phone: {PhoneNumber}";
        }
    }
    public class Fish
    {
        public double Length { get; set; }
        public double Weight { get; set; }
        public string Species { get; set; }
        public Fisher Catcher { get;}
        public string Place { get; set; }
        public string Location { get; set; }
        public Fish() { }
        public Fish(string species,double length, double weight, string place, string location, Fisher catcher)
        {
            Species = species;
            Length = length;
            Weight = weight;
            Place = place;
            Location = location;
            Catcher = catcher;
        }
        public override string ToString()
        {
            return $"- Species: {Species} {Length.ToString(CultureInfo.InvariantCulture)}cm {Weight.ToString(CultureInfo.InvariantCulture)}Kg\n- Place: {Place}\n- Location: {Location}";
        }
    }
    internal class MyFishAppProgram
    {
        static void MyFishApp()
        {
            FishRegister fishregister = new FishRegister();
            //For the purpose of observing the apps functions creating a fisher
            //and some fish for the fisher
            fishregister.Fishers.Add(new Fisher("Kalle Kalastaja","045101010"));
            fishregister.AddFish("Kalle Kalastaja", "Pike", 102, 2.9, "Kymijoki", "Kouvola");
            fishregister.AddFish("Kalle Kalastaja", "Perch", 15.2, 0.7, "Särkilampi", "Savitaipale");
            Console.WriteLine("Welcome to MyFishApp");
            while(true)
            {
                Console.Write("\nWould you like to:\n[A/a] - Add a new fisher to Fishregister\n[F/f] - Add a new fish to fisher in the Fishregister\n[R/r] - List all the Fishers in the FishRegister\n[L/l] - List all the fish in the fishregister\n[O/o] - List all fishes ordered by weight(heaviest first)\n[E/e] - Exit\n\nSelection: ");
                string input = Console.ReadLine();
                if(input == "A" || input == "a")
                {
                    Console.WriteLine("\nAdding new Fisher to FishRegister\n!Leave empty input to cancel!\n");
                    while (true)
                    {
                        Console.Write("Name: ");
                        string inputname = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputname))
                        {
                            break;
                        }
                        Console.Write("PhoneNumber: ");
                        string inputphonenumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputphonenumber))
                        {
                            break;
                        }
                        Console.WriteLine(fishregister.AddFisher(inputname, inputphonenumber));
                        break;
                    }
                }
                else if (input == "F" || input == "f")
                {
                    Console.WriteLine("\nAdding new Fish to FishRegister\n!Leave empty input to cancel!\n");
                    while (true)
                    {
                        Console.Write("Name of the Fisher: ");
                        string inputname = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputname))
                        {
                            break;
                        }
                        Console.Write("Species: ");
                        string inputspecies = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputspecies))
                        {
                            break;
                        }
                        Console.Write("Length: ");
                        string inputlength = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputlength))
                        {
                            break;
                        }
                        if (!double.TryParse(inputlength,out double parsedlength))
                        {
                            Console.WriteLine("Please input length as numbers! Example: 3,25");
                            continue;
                        }                   
                        Console.Write("Weight: ");
                        string inputweight = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputweight))
                        {
                            break;
                        }
                        if (!double.TryParse(inputweight,out double parsedweight))
                        {
                            Console.WriteLine("Please input weight as numbers! Example: 3,25");
                            continue;
                        }
                        Console.Write("Place: ");
                        string inputplace = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputplace))
                        {
                            break;
                        }
                        Console.Write("Location: ");
                        string inputlocation = Console.ReadLine();
                        if (string.IsNullOrEmpty(inputlocation))
                        {
                            break;
                        }
                        Console.WriteLine(fishregister.AddFish(inputname, inputspecies, parsedlength, parsedweight, inputplace, inputlocation));
                        break;
                    }
                }
                else if (input == "R" || input == "r")
                {
                    foreach (var fisher in fishregister.Fishers)
                    {
                        Console.WriteLine(fisher.ToString());
                    }
                }
                else if (input == "L" || input == "l")
                {
                    Console.WriteLine("All fish in the FishRegister:\n");
                    foreach (Fisher fisher in fishregister.Fishers)
                    {
                        Console.WriteLine($"Fisher {fisher.Name} has caught following fish:");
                        foreach (Fish fish in fisher.CatchedFish)
                        {
                            Console.WriteLine($"{fish.ToString()}\n");
                        }
                    }
                }
                else if (input == "O"||input == "o")
                {
                    Console.WriteLine("*** All fish in FishRegister(sorted by Weight): ***\n");
                    foreach (var item in fishregister.SortFishes())
                    {
                        Console.WriteLine(item.ToString() + $"\n- Fisher: {item.Catcher.Name}\n");
                    }

                }
                else if (input == "E" || input == "e")
                {
                    Console.WriteLine("Exiting MyFishApp...");
                    break;
                }
                else { Console.WriteLine("Invalid input! Please use the inputs given!"); }
            }
        }
        static void Main(string[] args)
        {
            MyFishApp();
        }
    }
}
