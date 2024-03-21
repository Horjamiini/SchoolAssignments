using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Amplifier
    {
        private int volume;
        public string Name { get; set; }
        public int Volume { get { return volume; } }
        //constuctors
        public Amplifier()
        {

        }
        public Amplifier(int volume, string name)
        {
            this.volume = volume;
            Name = name;
        }
        //methods
        public bool ChangeVolume(int changevolume,out string message)
        {
            if (changevolume > 100 )
            {
                volume = 100;
                message = $"Too much volume - {Name} is set to {Volume}";
                return false;
            }
            else if (changevolume == volume)
            {
                message = $"{Name} volume is already at {Volume}";
                return false;
            }
            else if (changevolume < 0) 
            {
                volume = 0;
                message = $"Too low volume - {Name} is set to {Volume}";
                return false;
            }
            else
            {
                volume = changevolume;
                message = $"{Name} volume is set to : {Volume}";
                return true;
            }

        }
    }
    internal class Program
    {
        static void TestAmplifier()
        {
            Amplifier vahvistin = new Amplifier() {Name = "Marshall" };

            Console.WriteLine($"Amplifier {vahvistin.Name} ready, give an empty input to exit setup");
            while(true)
            {
                Console.Write("Give a new volume value (0-100): ");
                string volumeAsString = Console.ReadLine();
                if(string.IsNullOrEmpty(volumeAsString))
                {
                    Console.WriteLine("Exiting amplifier setup");
                    break;
                }
                if(int.TryParse(volumeAsString,out int volume))
                {
                    if (vahvistin.ChangeVolume(volume,out string message))
                    {
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }
                }
                else
                {
                    Console.WriteLine($"{vahvistin.Name} needs numbers to change volume");
                }
            }
        }
        static void Main(string[] args)
        {
            TestAmplifier();
        }
    }
}
