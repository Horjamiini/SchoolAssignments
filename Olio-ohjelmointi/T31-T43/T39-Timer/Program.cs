using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Timer
    {
        private string notification = "Wake wake, the little bird";
        public string Notification { get { return notification; } set { notification = value; } }

        public int CalculateTime(string timetype,int time)
        {
            if (timetype == "M" || timetype == "m")
            {
                int alarmtime = time * 60 * 1000;
                return alarmtime;
            }
            else
            {
                int alarmtime = time * 1000;
                return alarmtime;
            }
        }
        public bool CheckTimeInterval(int time,out string message)
        {
            if (time < 1)
            {
                message = "Cannot set time for alarm lower than 1 second";
                return false;
            }
            else if (time > 3600000)
            {
                message = "Cannot set time for alamr higher than 60 minutes";
                return false;
            }
            else
            {
                message = "Alarm started!";
                return true;
            }
        }
        public string UseAlarm(int time)
        {

                System.Threading.Thread.Sleep(time);
                return $"{Notification}";
        }
    }
    internal class Program
    {
        static void TestTimer()
        {
            Timer alarm = new Timer();
            Console.WriteLine("Setting new alarm");
            Console.Write("Input notification for alarm(empty input will use default notifiaction): ");
            string notif = Console.ReadLine();
            if (notif != "")
            {
                alarm.Notification = notif;
            }
            Console.Write("Would you like to set the alarm in seconds[s] or minutes[m]: " );
            string input = Console.ReadLine();
            if (input == "M" ||input == "m")
            {
                Console.Write("Inupt minutes for your alarm: ");
                string minutes = Console.ReadLine();
                if (int.TryParse(minutes, out int parsedminutes))
                {
                    if (alarm.CheckTimeInterval(alarm.CalculateTime(input,parsedminutes), out string msg))
                    {
                        Console.WriteLine(msg);
                        Console.WriteLine(alarm.UseAlarm(alarm.CalculateTime(input, parsedminutes)));
                    }
                    else { Console.WriteLine(msg); }
                }
                else 
                {
                    Console.WriteLine("Invalid input please input minutes as a whole number!");
                }

            }
            else if (input == "S" || input == "s")
            {
                Console.Write("Input seconds for alarm: ");
                string seconds = Console.ReadLine();
                if(int.TryParse(seconds,out int parsedseconds))
                {
                    if (alarm.CheckTimeInterval(alarm.CalculateTime(input,parsedseconds),out string msg))
                    {
                        Console.WriteLine(msg);
                        Console.WriteLine(alarm.UseAlarm(alarm.CalculateTime(input, parsedseconds)));
                    }
                    else { Console.WriteLine(msg); }
                    
                }
                else
                {
                    Console.WriteLine("Invalid input please input seconds as a whole number!");
                }
            }
            else { Console.WriteLine("Invalid input, please try again!"); }


        }
        static void Main(string[] args)
        {
            TestTimer();
        }
    }
}
