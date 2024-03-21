using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Tank
    {
        //fields
        private int crewnumber = 4;
        private float speed = 0;
        private float speedmax = 100;
        //properties
        public string Name { get; set; }
        public string Type { get; set; }
        public int CrewNumber 
        { 
            get { return crewnumber; }
            set 
            { 
                if (value < 2 || value > 6)
                {
                    crewnumber = CrewNumber;
                }
                else { crewnumber = value; }
            } 
        }
        public float Speed { get { return speed; } }
        public float SpeedMax { get { return speedmax; } }
        //constructors
        //methods
        public float AccelerateTo(float moreSpeed, out string message)
        {
            if (moreSpeed > SpeedMax)
            {
                message = $"Given speed ({moreSpeed}) is too high, limiter says no!";
                return speed;
            }
            else if ( moreSpeed == speed || moreSpeed < speed)
            {
                message = $"Could not accelerate to ({moreSpeed}), speed is already higher ({Speed})!";
                return speed;
            }
            else 
            {
                
                message = $"Accelerated to {moreSpeed}";
                speed = moreSpeed;
                return speed;
            }
        }
        public float SlowTo(float lessSpeed, out string message)
        {
            if (lessSpeed < 0)
            {
                message = $"Given speed ({lessSpeed}) is too low, you can't have negative speed!";
                return speed;
            }
            else if ( lessSpeed == speed || lessSpeed > speed)
            {
                message = $"Could not slow down to {lessSpeed}, speed is already lower ({Speed})";
                return speed;
            }
            else
            {
                message = $"Slowed down to {lessSpeed}";
                speed = lessSpeed;
                return speed;
            }
        }
        public override string ToString()
        {
            return $"Name:{Name}\nType:{Type}\nCrewNumber:{CrewNumber}\nSpeed:{Speed}";
        }
    }
    internal class Program
    {
        static void TestTank()
        {
            Tank tank = new Tank(){Name = "Tiger", Type = "Pantzer"};
            Console.WriteLine($"Amount of crewmates: {tank.CrewNumber}");
            tank.CrewNumber = 5;
            Console.WriteLine($"Amount of crewmates: {tank.CrewNumber}");
            tank.CrewNumber = 7;
            Console.WriteLine($"Amount of crewmates: {tank.CrewNumber}");            
            Console.WriteLine($"Speed is: {tank.Speed}");
            tank.AccelerateTo(60F, out string accmessage);
            Console.WriteLine(accmessage);
            Console.WriteLine($"Speed is: {tank.Speed}");
            tank.AccelerateTo(45F,out string accmessage1);
            Console.WriteLine(accmessage1);
            Console.WriteLine($"Speed is: {tank.Speed}");
            tank.AccelerateTo(150F, out string accmessage2);
            Console.WriteLine(accmessage2);
            Console.WriteLine($"Speed is: {tank.Speed}");
            tank.SlowTo(25F,out string slowmessage);
            Console.WriteLine(slowmessage);
            Console.WriteLine($"Speed is: {tank.Speed}");
            tank.SlowTo(35F, out string slowmessage1);
            Console.WriteLine(slowmessage1);
            Console.WriteLine($"Speed is: {tank.Speed}");
            tank.SlowTo(-1F,out string slowmessage2);
            Console.WriteLine(slowmessage2);
            Console.WriteLine($"Speed is: {tank.Speed}");
            
        }
        static void Main(string[] args)
        {
            TestTank();
        }
    }
}
