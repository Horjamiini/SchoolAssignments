using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        public static void CountScore()
        {
            int[] scores = new int[5];
            for (int i = 0; i < 5; ++i)
            {
                Console.Write("Give points: ");
                string scoreAsString = Console.ReadLine();

                bool parseScore = int.TryParse(scoreAsString, out int score);

                    if (parseScore == true)
                    {
                        scores[i] = score;
                    }
                    else { throw new Exception("That wasn't a number!"); }
            }

            int big = scores.Max();
            int small = scores.Min();
            int result = 0;

            foreach (int value in scores)
            {
                result += value;
            }
            result -= big;
            result -= small;

            Console.WriteLine($"Total points: {result}");
        }

        static void Main(string[] args)
        {
            try
            {
                CountScore();
            }
            catch
            {
                Console.WriteLine("Please input numbers only!");
            }
        }
    }
}
