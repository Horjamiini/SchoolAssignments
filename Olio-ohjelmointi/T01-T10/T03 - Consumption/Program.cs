using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        // Luodaan metodista Tuple, jotta saadaan palautetua kaksi arvoa Main:iin
        public static double CalculateConsumption(double distance, out double cost)
        {
            Random r = new Random();

            double distcalc = distance / 100;

            //NextDouble ottaa numeron 0.0 ja 1.0 välillä. Saadun luvun kertominen halutun välin maksimin ja minimin erotuksella
            // ja lisäämällä halutun välin pienin luku antavat tulokseksi satunnaisen luvun halutulta väliltä.
            double fuel = (r.NextDouble() * (9 - 6) + 6);
            double price = (r.NextDouble()* (2.50 - 1.75) + 1.75);

            // Laskutuoimukset joilla saadaan bensan kulutus sekä hinta laskettua
            // Luvut pyöristetään 2 desimaalin tarkkuuteen
            double consumption = Math.Round(fuel * distcalc, 2);
            cost = Math.Round(consumption * price, 2);

            return consumption;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter distance traveled: ");
            string distAsString = Console.ReadLine();

            if (double.TryParse(distAsString, out double dist))
            {
                double cons = CalculateConsumption(dist, out double cost);
                Console.WriteLine($"Fuel consumption is {cons} liters and it costs {cost} euros.");
            }
            else { Console.WriteLine("Distance must be given as a number!"); }
        }
    }
}
