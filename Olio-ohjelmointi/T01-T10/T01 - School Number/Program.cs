using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        public static void CountGrade()
        {
       
            Console.Write("Give points to reflect the grade: ");
            string gradeAsString = Console.ReadLine();

            bool gradeParse = int.TryParse(gradeAsString, out int grade);

            if (gradeParse)
            {
                if (grade >= 0 && grade <= 19) { Console.WriteLine("Grade is: 0"); }
                else if (grade >= 20 && grade <= 29) { Console.WriteLine("Grade is: 1"); }
                else if (grade >= 30 && grade <= 39) { Console.WriteLine("Grade is: 2"); }
                else if (grade >= 40 && grade <= 49) { Console.WriteLine("Grade is: 3"); }
                else if (grade >= 50 && grade <= 59) { Console.WriteLine("Grade is: 4"); }
                else if (grade >= 60 && grade <= 70) { Console.WriteLine("Grade is: 5"); }
                else { Console.WriteLine("Given point are out of courses scope!"); }
            }
            else Console.WriteLine("Invalid input! Please input a number to evaluate the course!");
        }
        static void Main(string[] args)
        {
            CountGrade();

        }
    }
}
