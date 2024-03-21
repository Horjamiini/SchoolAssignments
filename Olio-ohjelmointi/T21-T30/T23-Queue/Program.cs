using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class CheckoutQueue
    {
        private Queue<string> _jono;
        public Queue<string> Jono { get { return _jono; } }
        public int Length { get { return Jono.Count(); } }
        //constructor
        public CheckoutQueue()
        {
            _jono= new Queue<string>();
        }
        //methods
        public void GoToQueue(string name)
        {
            Jono.Enqueue(name);
        }
        public void ExitQueue()
        {

            Jono.Dequeue();
        }
        public void ExitFromMiddleOfQueue(string name)
        {
            _jono = new Queue<string>(Jono.Where(x => x != name));
        }
    }
    internal class Program
    {
        static void TestQueue()
        {
            CheckoutQueue kassajono = new CheckoutQueue();
            Console.WriteLine("----- Testataan asiakasjonoa kassalle -----");
            while (true)
            {
                Console.WriteLine("Anna jonoon tulevan asiakkaan nimi (enter lopettaa)");
                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"Jonossa on nyt {kassajono.Length} asiakasta:");
                    foreach (var item in kassajono.Jono)
                    {
                        Console.WriteLine(item);
                    }
                    while(kassajono.Length > 0)
                    {
                        Console.WriteLine("----Palvellaan jonon ensimmäinen asiakas----");
                        Console.WriteLine($"Palvelen nyt asiakasta: {kassajono.Jono.Peek()}");
                        kassajono.ExitQueue();
                        System.Threading.Thread.Sleep(2500);


                    }
                    Console.WriteLine("Kaikki asiakkaat palveltu!");
                    break;
                }
                kassajono.GoToQueue(input);
                Console.WriteLine($"Jonossa on nyt {kassajono.Length} asiakasta:");
                foreach (var item in kassajono.Jono)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void TestQueueAgain()
        {
            CheckoutQueue festivaalijono = new CheckoutQueue();
            Console.WriteLine("----- Testataan asiakasjonoa kassalle -----");
            while (true)
            {
                Console.WriteLine("Anna jonoon tulevan asiakkaan nimi (enter lopettaa ja '!' saa henkilön poistumaan jonosta)");
                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"Jonossa on nyt {festivaalijono.Length} asiakasta:");
                    foreach (var item in festivaalijono.Jono)
                    {
                        Console.WriteLine(item);
                    }
                    while (festivaalijono.Length > 0)
                    {
                        Console.WriteLine("----Palvellaan jonon ensimmäinen asiakas----");
                        Console.WriteLine($"Palvelen nyt asiakasta: {festivaalijono.Jono.Peek()}");
                        festivaalijono.ExitQueue();
                        System.Threading.Thread.Sleep(2500);


                    }
                    Console.WriteLine("Kaikki asiakkaat palveltu!");
                    break;
                }
                if (input == "!")
                {
                    Console.Write("Who is going to leave the queue?: ");
                    string leaveInput = Console.ReadLine();
                    if (festivaalijono.Jono.Contains(leaveInput))
                    {
                        Console.WriteLine($"{leaveInput} is leaving the queue...");
                        festivaalijono.ExitFromMiddleOfQueue(leaveInput);
                        Console.WriteLine($"Jonossa on nyt {festivaalijono.Length} asiakasta:");
                        foreach (var item in festivaalijono.Jono)
                        {
                            Console.WriteLine(item);
                        }
                    }

                    else
                    {
                        Console.WriteLine("That person is not in queue");
                        Console.WriteLine($"Jonossa on nyt {festivaalijono.Length} asiakasta:");
                        foreach (var item in festivaalijono.Jono)
                        {
                            Console.WriteLine(item);
                        };
                    }
                }
                else
                {
                    festivaalijono.GoToQueue(input);
                    Console.WriteLine($"Jonossa on nyt {festivaalijono.Length} asiakasta:");
                    foreach (var item in festivaalijono.Jono)
                    {
                        Console.WriteLine(item);
                    };
                }

            }
        }
        static void Main(string[] args)
        {
            TestQueue();
            TestQueueAgain();
        }
    }
}
