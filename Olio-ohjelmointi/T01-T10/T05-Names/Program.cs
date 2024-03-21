using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SHAA3209
{

    public struct Person
    {
        public string Name;
        public int BirthYear;
        private int ThisYear;

        public Person(string name, int birthyear)
        {
            ThisYear = DateTime.Now.Year;
            Name = name;
            BirthYear = ThisYear - birthyear;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                Console.WriteLine("Please, give names and birth year of a person. Empty input will stop the input.");
                Console.Write("Give a name: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) { break; }
                string[] inputs = input.Split(',');

                try
                {
                    bool yearAsString = int.TryParse(inputs[1], out int year);
                    if (yearAsString)
                    {

                        people.Add(new Person(inputs[0], year));


                    }
                    else { Console.WriteLine("Your birthyear wasn't a number"); }
                }
                catch
                {
                    Console.WriteLine("Your input format was not correct! Please use name,birthyear");
                }
            }
            // Kaksi eri tapaa suorittaa sorttaus nuorimmasta vanhimpaan, molemmat toimivat
            // people.Sort((person1, person2) => person1.BirthYear.CompareTo(person2.BirthYear));
            people.Sort(
                delegate(Person person1, Person person2)
                {
                    return person1.BirthYear.CompareTo(person2.BirthYear);
                });
            Console.WriteLine($"\n{people.Count} names were given:");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{people[i].Name} is {people[i].BirthYear} years old.");
            }
        }
    }
}
