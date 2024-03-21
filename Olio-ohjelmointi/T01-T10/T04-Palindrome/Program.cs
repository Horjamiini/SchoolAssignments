using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        public static bool TestPalindrome(string input)
        {
            string reverse = "";

                for (int i = input.Length - 1; i >= 0; --i)
                {
                    reverse += input[i].ToString();
                }
                if (reverse == input)
                { 
                    return true;
                }
                else { return false; }
        }
        static void Main(string[] args)
        {
            Console.Write("Give me a string or a sentence to check if it is a palindrome: ");
            string input = Console.ReadLine();

            if (input != "")
            {
                if (TestPalindrome(input))
                {
                    Console.WriteLine($"{input} is a palindrome!");
                }
                else
                {
                    Console.WriteLine($"{input} is not a palindrome!");
                }
            }
            else
            {
                Console.WriteLine("Your input was empty!");
            }
        }
    }
}
