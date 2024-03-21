using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SHAA3209
{
    //comments are in the Main
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string firstname,string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    internal class Program
    {
        static void TestRandomList()
        {
            Random r = new Random();
            List<Person> persons = new List<Person>();
            int rnd = r.Next(10000);
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {

                persons.Add(new Person(Randomizer.CreateFirstName(),Randomizer.CreateLastName()));
            }
            timer.Stop();
            Console.WriteLine("List Collection:\n- Adding time: {0}ms\n- Persons count: {1}\n- Random person: {2} {3}\n", timer.ElapsedMilliseconds, persons.Count, persons[rnd].FirstName, persons[rnd].LastName);
            Console.WriteLine("Finding persons in collection(by first name):");
            FindPerson(persons);

        }
        static void TestRandomDictionary()
        {
            Random r = new Random();
            int rnd = r.Next(10000);
            Dictionary<string,Person> persondictionary = new Dictionary<string,Person>();
            var dTimer = Stopwatch.StartNew();
            for (int i = 0;i < 10000; i++)
            {
                string firstname = Randomizer.CreateFirstName();
                if (!persondictionary.ContainsKey(firstname))
                {

                    persondictionary.Add(firstname, new Person(firstname, Randomizer.CreateLastName()));
                }
                else { i--; }
            }
            dTimer.Stop();
            Console.WriteLine("\nDictionary Collection:\n- Adding time: {0}ms\n- Persons count: {1}\n- Random person: {2}\n", dTimer.ElapsedMilliseconds, persondictionary.Count, persondictionary.ElementAt(rnd).Value);
            Console.WriteLine("Finding persons in collection(by first name):");        
            FindPersonsDict(persondictionary);
        }
        static void Main(string[] args)
        {
            TestRandomList();
            TestRandomDictionary();
            //Collection had a significant difference since dictionariies need to use key for each value. This makes the code litte bit different and little bit slower since
            //any of the keys cannot appear more than once in dictionary. List is in a way easier to use since you can just add the Persons to the List, but if you would want
            //every entry to be individual it might be smarter to use dictionary.

            // Even though dictionary was slower than List it wasn't by a huge amount, but if we had even bigger data or more complex code the speed difference might show even more?
        }

        private static void FindPerson(List<Person> persons)
        {
            List<Person> foundPersons = new List<Person>();
            var findpersonTimer = Stopwatch.StartNew();
            for (int i = 0;i < 1000; i++)
            {
                string randomname = Randomizer.CreateFirstName();
                foreach (Person person in persons)
                {
                    if (person.FirstName == randomname)
                    {
                        foundPersons.Add(person);
                    }
                }
            }
            findpersonTimer.Stop();
            if (foundPersons.Count == 0)
            {
                Console.WriteLine("No matches found!");
            }
            else
            {
                foreach (Person person in foundPersons)
                {
                    Console.WriteLine($"- Found person with {person.FirstName} firstname : {person.FirstName} {person.LastName}");
                }
            }
            Console.WriteLine($"- Persons tried to find: 1000\nTotal finding time: {findpersonTimer.ElapsedMilliseconds}ms");
        }
        private static void FindPersonsDict(Dictionary<string,Person> dict)
        {
            Dictionary<string,Person> foundPersons = new Dictionary<string,Person>();
            var findTimer = Stopwatch.StartNew();
            for (int i = 0;i < 1000; i++)
            {
                string randomname = Randomizer.CreateFirstName();
                if (dict.ContainsKey(randomname))
                {
                    Person person = dict[randomname];
                    foundPersons.Add(randomname, person);
                }
            }
            findTimer.Stop();
            if (foundPersons.Count < 1)
            {
                Console.WriteLine("No matches found!");
            }
            else
            {
                foreach (KeyValuePair<string,Person> item in foundPersons)
                {
                    Console.WriteLine($"- Found person with {item.Value.FirstName} firstname : {item.Value.FirstName} {item.Value.LastName}");
                }
                Console.WriteLine($"- Persons tried to find: 1000\nTotal finding time: {findTimer.ElapsedMilliseconds}ms");
            }
        }
    }
}
