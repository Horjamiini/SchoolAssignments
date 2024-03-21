using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Elevator
    {
        private int floor = 1;
        //properties
        public int Floor { get { return floor; } }
        //methods
        public bool GoTo(int changefloor, out string message)
        {
            if (changefloor < 0)
            {
                message = "Floor is too small!";
                return false;
            }
            else if (changefloor > 5)
            {
                message = "Floor is too big!";
                return false;
            }
            else if (changefloor == floor)
            {
                message = "You are currently at this floor";
                return false;
            }
            else
            {
                floor = changefloor;
                message = "Vroom vroom changin floors!";
                return true;
            }
        }
        public override string ToString()
        {
            return $"Elevator is currently at floor {Floor}"; 
        }

    }
    internal class Program
    {
        static void TestElevator()
        {
            Elevator elevator = new Elevator();
            while (true)
            {
                Console.WriteLine($"Elevator is currently at floor: {elevator.Floor}");
                Console.WriteLine("Give empty input to exit the elevator!");
                Console.Write("Give a floornumber(1-5): ");
                string floornumberAsString = Console.ReadLine();
                if (string.IsNullOrEmpty(floornumberAsString))
                {
                    Console.WriteLine("You are now exiting the elevator...");
                    break; 
                }
                if (int.TryParse(floornumberAsString, out int floornumber))
                {
                    if (elevator.GoTo(floornumber,out string message))
                    {
                        Console.WriteLine("...");
                        System.Threading.Thread.Sleep(250);
                        Console.WriteLine("...");
                        System.Threading.Thread.Sleep(250);
                        Console.WriteLine("...");
                        System.Threading.Thread.Sleep(250);
                        Console.WriteLine("Bling!");
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }
                }
                else
                {
                    Console.WriteLine("Press the numbers to operate the elevator!");
                }
            }
        }
        static void Main(string[] args)
        {
            TestElevator();
        }
    }
}
