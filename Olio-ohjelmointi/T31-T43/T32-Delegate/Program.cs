using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        delegate string TransformString(string str);
        static void TestDelegate()
        {
            TransformString ts = TransformUpperCase;

            Console.Write("Enter the string to process:");
            string input = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Choose the treatment you want, you can give several treatments at once as one string, e.g. '123'");
                Console.WriteLine("1: To capital letters\n2: lowercase\n3: as a title\n4: as a palindrome\n0: termination\n");
                Console.Write("Selection: ");
                string action = Console.ReadLine();
                Console.WriteLine("");
                for (int i = 0; i < action.Length; i++)
                {
                    if (action[i] == '1')
                    {
                        ts += TransformUpperCase;
                        Console.WriteLine($"{input} changed to {ts(input)}");
                    }
                    else if (action[i] == '2')
                    {
                        ts += TransformLowerCase;
                        Console.WriteLine($"{input} changed to {ts(input)}");
                    }
                    else if (action[i] == '3')
                    {
                        ts += TransformTitle;
                        Console.WriteLine($"{input} changed to {ts(input)}");
                    }
                    else if (action[i] == '4')
                    {
                        ts += TransformPalindrome;
                        Console.WriteLine($"{input} changed to {ts(input)}");
                    }
                    else if (action == "0")
                    {
                        Console.WriteLine("Exiting process...");
                    }
                    else
                    {
                        Console.WriteLine("Non valid input\n");
                    }
                }
                if (action == "0")
                {
                    break;
                }
                Console.WriteLine("");
            }

        }
        static void Main(string[] args)
        {
            TestDelegate();
        }

        static string TransformUpperCase(string str)
        {
            return str.ToUpper();
        }
        static string TransformLowerCase(string str)
        {
            return str.ToLower();
        }
        static string TransformTitle(string str)
        {
            return $"{str.FirstOrDefault().ToString().ToUpper()}{str.Substring(1)}";
        }
        static string TransformPalindrome(string str)
        {
            char[] cArray = str.ToCharArray();
            string reverse = "";
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

    }
}
