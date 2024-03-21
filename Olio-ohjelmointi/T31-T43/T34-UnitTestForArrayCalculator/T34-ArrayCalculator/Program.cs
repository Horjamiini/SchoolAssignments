using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class ArrayCalculator
    {
        public static double Sum(double[] array)
        {
            double sum = Math.Round(array.Sum(),2);
            return sum;
        }
        public static double Average(double[] array)
        {
            double avg = Math.Round(array.Average(),2);
            return avg;
        }
        public static double Min(double[] array)
        {
            double min = Math.Round(array.Min(), 2);
            return min;
        }
        public static double Max(double[] array)
        {
            double max = Math.Round(array.Max(), 2);
            return max;
        }
    }
    internal class Program
    {
        static void TestArrayCalculator()
        {
            // if methods are given empty arrays as parameter only the Sum()-method works. This can be seen from the unit tests
            // where only the Sum()-method has both tests passing since all the other methods throw an error.
            // This means 5/8 test pass.
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            Console.WriteLine($"Sum = {ArrayCalculator.Sum(array)}");
            Console.WriteLine($"Average = {ArrayCalculator.Average(array)}");
            Console.WriteLine($"Min = {ArrayCalculator.Min(array)}");
            Console.WriteLine($"Max = {ArrayCalculator.Max(array)}");
        }
        static void Main(string[] args)
        {
            TestArrayCalculator();
        }
    }
}
