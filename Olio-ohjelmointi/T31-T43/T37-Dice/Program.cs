using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        static void TestDice()
        {
            Dice dice = new Dice();
            dice.RollDiceOnce();
            Console.WriteLine($"Dice, one test throw value is {dice.Number}");
            Console.Write("How many times you want to throw the dice: ");
            string input1 = Console.ReadLine();
            if (int.TryParse(input1, out int num1))
            {
                Console.WriteLine($"Dice is thrown {num1} times, average is: {dice.RollDiceAverage(num1)}");
            }
            else { Console.WriteLine($"{input1} is not a number!"); }


            Console.Write("\nHow many times you want to throw the dice: ");
            string input2 = Console.ReadLine();
            if (int.TryParse(input2, out int num2))
            {
                Console.WriteLine($"Dice is thrown {num2} times\n{dice.RollDiceWithCounts(num2)}");
            }
            else { Console.WriteLine($"{input2} is not a number!"); }
        }
        static void Main(string[] args)
        {
            TestDice();
        }
    }
}
