using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public abstract class ElectricalDevice
    {
        public bool On { get; set; }
        public float Power { get; set; }
    }
    public class Radio : ElectricalDevice
    {
        private int volume;
        private float frequency;
        public int Volume { get { return volume; } }
        public float Frequency { get { return frequency; } }
        //methods
        public void ChangePower()
        {
            if(On == true)
            {
                On = false;
            }
            else
            {
                On = true;
            }
        }
        public int ChangeVolume(int volume)
        {
            if (On == false)
            {
                return this.volume;
            }
            else
            {
                if (volume > 9)
                {
                    this.volume = 9;
                    return this.volume;
                }
                else if (volume < 0)
                {
                    this.volume = 0;
                    return this.volume;
                }
                else
                {
                    this.volume = volume;
                    return this.volume;
                }
            }
        }
        public float ChangeFreq(float frequency)
        {
            if (On == false)
            {
                return this.frequency;
            }
            else
            {
                if (frequency > 26000.0F)
                {
                    this.frequency = 26000.0f;
                    return this.frequency;
                }
                else if (frequency < 2000.0F)
                {
                    this.frequency = 2000.0F;
                    return this.frequency;
                }
                else
                {
                    this.frequency = frequency;
                    return this.frequency;
                }
            }
        }
        public override string ToString()
        {
            return $"PowerOn: {On}\nPower: {Power}W\n Volume: {Volume}\n Frequency: {Frequency}";
        }
    }
    internal class Program
    {
        static void TestRadio()
        {
            Radio radio = new Radio();
            radio.On = false;
            radio.Power= 1000;
            Console.WriteLine(radio.ToString());
            radio.ChangeFreq(21000.0F);
            radio.ChangeVolume(5);
            //Volume and frequency will not be set because Power is off(false)
            Console.WriteLine(radio.ToString());
            radio.ChangePower();
            radio.ChangeFreq(21000.0F);
            radio.ChangeVolume(5);
            // When power is changed on(true) volume and frequency can be set
            Console.WriteLine(radio.ToString());
            radio.ChangeVolume(11);
            radio.ChangeFreq(27000.0F);
            //Volume and frequency cannot be adjusted over the limit that is set in the methods
            //values will be changed to the highest poosible value
            Console.WriteLine(radio.ToString());
            radio.ChangePower();
            //when radio is turned off it will "remember" the volume and frequency that it had when it was on
            Console.WriteLine(radio.ToString());

        }
        static void Main(string[] args)
        {
            TestRadio();
        }
    }
}
