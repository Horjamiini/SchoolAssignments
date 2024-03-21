using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Television
    {
        //fields
        private const int maxVolume = 100;
        private const int minVolume = 1;
        private int volume;
        private int channel;
        //properties
        public string Model { get; set; }
        public bool Power { get; set; }
        public int Channel 
        { 
            get { return channel; }
        }
        public int Volume 
        { 
            get { return volume; }
        }
        //constructors
        public Television()
        {

        }
        public Television(int volume, int channel, string model, bool power)
        {
            this.volume = volume;
            this.channel = channel;
            Model = model;
            Power = power;
        }

        //methods
        public bool IncreaseVolume(int increment)
        {
            if (increment + volume >= maxVolume )
            {
                return false;
            }
            else
            {
                volume += increment;
                return true;
            }
        }
        public bool DecreaseVolume(int decrement)
        {
            if (decrement + volume <= minVolume) 
            {
                return false;
            }
            else
            {
                volume -= decrement;
                return true;
            }
        }
        public void ChangeChannel(int channelnumber)
        {
            channel = channelnumber;
        }
        public string ShowTv()
        {
            return $"\n{Model}\n Power: {ShowPower()}\n Channel: {Channel}\n Volume: {Volume}";
        }
        public void ChangeTvPower(bool power)
        {
            Power = power;
        }
        public string ShowPower()
        {
            if (Power == true)
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }
    }
    internal class Program
    {
        static void TestTV()
        {
            Television telkkari = new Television() { Model = "JVC", Power = true};
            Console.WriteLine("Change channel with number keys and increase or decrease volume with up and down arrowkeys");
            Console.WriteLine("Show TV's status with 'S'(this can be done even if TV is off) and turn power ON/OFF with 'T' (ESC to exit at any time)");
            Console.WriteLine("\nTv is now On");
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                { break; }
                else
                {
                    if (telkkari.Power == false)
                    {
                        if (key.Key == ConsoleKey.T)
                        {
                            Console.WriteLine($"{telkkari.Model} powering on...");
                            // Simulate turning on the TV
                            System.Threading.Thread.Sleep(2000);
                            telkkari.ChangeTvPower(true);
                            Console.WriteLine($"{telkkari.Model} is on standby");
                        }
                        else if (key.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"{telkkari.ShowTv()}");
                        }
                        else
                        {
                            Console.WriteLine($"{telkkari.Model} turn the TV on to use it!");
                        }
                    }
                    else 
                    {
                        if (key.Key == ConsoleKey.T)
                        {
                            Console.WriteLine($"{telkkari.Model} shutting down...");
                            System.Threading.Thread.Sleep(2000);
                            telkkari.ChangeTvPower(false);
                            Console.WriteLine($"{telkkari.Model} is turned off");
                        }
                        // check if pressed keys are number
                        // this limits the channel to being from range 0 - 9
                        else if (Int32.TryParse(key.KeyChar.ToString(), out int channelnumber))
                        {
                            Console.WriteLine($"Changing channel to {channelnumber}");
                            telkkari.ChangeChannel(channelnumber);
                        }
                        else if (key.Key == ConsoleKey.UpArrow)
                        {
                            if (telkkari.IncreaseVolume(1))
                            {
                                Console.WriteLine($"{telkkari.Model} Volume: {telkkari.Volume}");
                            }
                            else
                            {
                                Console.WriteLine($"{telkkari.Model} Volume is at max!");
                            }
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            if (telkkari.DecreaseVolume(1))
                            {
                                Console.WriteLine($"{telkkari.Model} Volume: {telkkari.Volume}");
                            }
                            else
                            {
                                Console.WriteLine($"{telkkari.Model} Volume is at min!");
                            }
                        }
                        else if (key.Key == ConsoleKey.S)
                        {
                            Console.WriteLine(telkkari.ShowTv());
                        }
                        else
                        {
                            Console.WriteLine("Please use numberkeys, Up or Down arrowkeys or 'S' to navigate TV!");
                            Console.WriteLine("Use 'T' to turn TV off");
                        }
                    }
                }
            }
        }
        static void TestConstructedTV()
        {
            Television telkkari = new Television(50,9,"Panasonic",false);
            Console.WriteLine("\n\n\nChange channel with number keys and increase or decrease volume with up and down arrowkeys");
            Console.WriteLine("Show TV's status with 'S'(this can be done even if TV is off) and turn power ON/OFF with 'T' (ESC to exit at any time)");
            Console.WriteLine("\nThis TV has been given default values in construction and at start is turned Off");
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                { break; }
                else
                {
                    if (telkkari.Power == false)
                    {
                        if (key.Key == ConsoleKey.T)
                        {
                            Console.WriteLine($"{telkkari.Model} powering on...");
                            // Simulate turning on the TV
                            System.Threading.Thread.Sleep(2000);
                            telkkari.ChangeTvPower(true);
                            Console.WriteLine($"{telkkari.Model} is on standby");
                        }
                        else if (key.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"{telkkari.ShowTv()}");
                        }
                        else
                        {
                            Console.WriteLine($"{telkkari.Model} is turned off");
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.T)
                        {
                            Console.WriteLine($"{telkkari.Model} shutting down...");
                            System.Threading.Thread.Sleep(2000);
                            telkkari.ChangeTvPower(false);
                        }
                        // check if pressed keys are number
                        // this limits the channel to being from range 0 - 9
                        else if (Int32.TryParse(key.KeyChar.ToString(), out int channelnumber))
                        {
                            Console.WriteLine($"Changing channel to {channelnumber}");
                            telkkari.ChangeChannel(channelnumber);
                        }
                        else if (key.Key == ConsoleKey.UpArrow)
                        {
                            if (telkkari.IncreaseVolume(1))
                            {
                                Console.WriteLine($"{telkkari.Model} Volume: {telkkari.Volume}");
                            }
                            else
                            {
                                Console.WriteLine($"{telkkari.Model} Volume is at max!");
                            }
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            if (telkkari.DecreaseVolume(1))
                            {
                                Console.WriteLine($"{telkkari.Model} Volume: {telkkari.Volume}");
                            }
                            else
                            {
                                Console.WriteLine($"{telkkari.Model} Volume is at min!");
                            }
                        }
                        else if (key.Key == ConsoleKey.S)
                        {
                            Console.WriteLine(telkkari.ShowTv());
                        }
                        else
                        {
                            Console.WriteLine("Please use numberkeys, Up or Down arrowkeys or 'S' to navigate TV!");
                            Console.WriteLine("Use 'T' to turn TV off");
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            TestTV();
            TestConstructedTV();
        }
    }
}
