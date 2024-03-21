using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class WashinMachine
    {
        private string program = "none";
        private const int minTemperature = 30;
        private const int maxTemperature = 90;
        private int temperature = 0;
        private const int minSpin = 0;
        private const int maxSpin = 1200;
        private int spin = 0;
        // properties
        public string Name { get; set; }
        public bool PowerOn { get; set; }
        public int Temperature
        {
            get { return temperature; }
        }
        public int Spin 
        {
            get { return spin; }
        }
        public string Program
        {
            get { return program; }
        }
        //constructors
        public WashinMachine()
        {
        }
        public WashinMachine(bool power, string name, int temperature, int spin)
        {
            PowerOn = power;
            Name = name;
            SetTemperature(temperature);
            SetSpin(spin);
        }
        // methods
        public string ShowStatus()
        {
            return $"\n{Name}\n Power:{PowerOn} \n Program: {Program}\n Temperature: {Temperature}\n Spin: {Spin}";
        }
        public bool SetWashProgram(string washProgram, out string message)
        {
            if (PowerOn == true)
            {
                if (washProgram == "Cotton" || washProgram == "Silk" || washProgram == "Handwash")
                {
                    program = washProgram;
                    message = "Program has been set\n";
                    return true;
                }
                else 
                {
                    message = "Invalid program\n";
                    return false;
                }
            }
            else
            {
                message = "Cannot set program, power is off\n";
                return false;
            }
        }
        public void SetTemperature(int washTemperature)
        {
            if (washTemperature > maxTemperature)
            {
                temperature = maxTemperature;
            }
            else if (washTemperature < minTemperature)
            {
                temperature = minTemperature;
            }
            else
            {
                temperature = washTemperature;
            }
        }
        public void SetSpin(int washSpin)
        {
            if (washSpin > maxSpin)
            {
                spin = maxSpin;
            }
            else if (washSpin < minSpin)
            {
                spin = minSpin;
            }
            else 
            {
                spin = washSpin;
            }
        }
    }
    internal class Program
    {
        static void TestWashingMachine()
        {
            WashinMachine pesukone = new WashinMachine();
            pesukone.Name = "Electrolux";
            pesukone.PowerOn = true;
            if (pesukone.SetWashProgram("Cotton", out string message))
            {
                Console.WriteLine($"{message}");
                Console.WriteLine(pesukone.ShowStatus());
            }
            else
            {
                Console.WriteLine($"{message}");
            }
            pesukone.SetTemperature(60);
            pesukone.SetSpin(1000);
            Console.WriteLine(pesukone.ShowStatus());
        }
        static void TestAnotherWashingMachine()
        {
            Console.WriteLine("Creating New Washingmachine with constructor");
            WashinMachine rosenlew = new WashinMachine(false, "rosenlew", 40, 500);
            Console.WriteLine(rosenlew.ShowStatus());
            Console.WriteLine("Trying to set program");
            if (rosenlew.SetWashProgram("Cotton", out string message))
            {
                Console.WriteLine($"{message}");
            }
            else
            {
                Console.WriteLine($"{message}");

            }
            Console.WriteLine("Turning power on and setting the program");
            rosenlew.PowerOn = true;
            if (rosenlew.SetWashProgram("Handwash", out string message2))
            {
                Console.WriteLine($"{message2}");
            }
            else
            {
                Console.WriteLine($"{message2}");

            }
            Console.WriteLine("Trying to set temperature and spin over the limits");
            rosenlew.SetTemperature(100);
            rosenlew.SetSpin(2000);
            Console.WriteLine("Values of temperature and spin have exceeded the maximum value, setting them to maximum");
            Console.WriteLine(rosenlew.ShowStatus());

        }
        static void Main(string[] args)
        {
            TestWashingMachine();
            Console.WriteLine("\n");
            TestAnotherWashingMachine();
        }
    }
}