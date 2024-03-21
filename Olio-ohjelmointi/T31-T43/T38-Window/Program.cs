using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        static void TestWindowConstructor()
        {
            Window window = new Window();
            Console.WriteLine("Is your desired window rectangle[R] or circle[C]? : ");
            string inputshape = Console.ReadLine();
            if (inputshape == "R" || inputshape == "r")
            {
                Console.WriteLine("Input windows needed height and width in meters [height;width]: ");
                string whinput = Console.ReadLine();
                if (string.IsNullOrEmpty(whinput)) { Console.WriteLine("Empty input..."); }
                try
                {
                    double[] whinputs = whinput.Split(';').Select(double.Parse).ToArray();
                    window.Height = whinputs[0];
                    window.Widht = whinputs[1];
                    window.CalculateAreaRectangle();
                    window.CalculateCircumferenceRectangle();
                    window.CalculateGlassAmountRectangle();
                    PrintRectangleWindow(window);
                    
                }
                catch
                {
                    Console.WriteLine("Your input format wasn't correct plese use height;width");
                }
            }
            else if (inputshape == "C" || inputshape == "c")
            {
                Console.WriteLine("Input windows needed diameter in meters: ");
                string dinput = Console.ReadLine();
                if (string.IsNullOrEmpty(dinput)) { Console.WriteLine("Empty input..."); }
                try
                {
                    double.TryParse(dinput, out double diameter);
                    window.Diameter = diameter;
                    window.CalculateAreaCircle();
                    window.CalculateCircumferenceCircle();
                    window.CalculateGlassAmountCircle();
                    PrintCircleWindow(window);
                }
                catch { Console.WriteLine("Your input was invalid please input desired diameter."); }
            }
            else { Console.WriteLine("invalid input please try again!"); }
        }
        static void Main(string[] args)
        {
            TestWindowConstructor();
        }
        private static void PrintRectangleWindow(Window window)
        {
            Console.WriteLine($"\n=====================\nDesired window:\n=====================\nHeight: {window.Height} || Width: {window.Widht}\n" +
                $"WindowArea: {window.Area}m^2 || WindowCircumference: {window.Circumference}m || GlassAmountNeeded: {window.Glassamount}m^2" +
                $"\n=====================");
        }
        private static void PrintCircleWindow(Window window)
        {
            Console.WriteLine($"\n=====================\nDesired window:\n=====================\nDiameter: {window.Diameter}\n" +
                $"WindowArea: {window.Area}m^2 || WindowCircumference: {window.Circumference}m || GlassAmountNeeded: {window.Glassamount}m^2" +
                $"\n=====================");
        }
    }
}
