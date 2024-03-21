using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class SaunaHeater
    {
        // fields
        private int temperature;
        private int humidity;
        private string info;
        #region properties
        public bool HeaterOn { get; set; }
        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (HeaterOn == false)
                {
                    temperature = 0;
                }
                else
                {
                    temperature = value;
                }
            }
        }
        public int Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                if (HeaterOn == false)
                {
                    humidity = 0;
                }
                else
                {
                    humidity = value;
                }
            }
        }
        
        #endregion

        #region methods
        public void TurnSaunaOn(int celsius, int percent)
        {
            HeaterOn = true;
            // set temperature and humidity when turning sauna on
            Temperature = celsius;
            Humidity = percent;
        }
        public void TurnSaunaOnDefault()
        {
            HeaterOn = true;
            Temperature = 80;
            Humidity = 80;
        }
        public void TurnSaunaOff()
        {
            // Turning sauna off defaults temperature
            // and humidity to 0
            HeaterOn = false;
            Temperature = SetTemperature();
            Humidity = SetHumidity();
        }
        public string ShowSaunaInfo()
        {
            // show the condition of sauna
            if (HeaterOn == true)
            {
                info = "Sauna is on";
            }
            else
            {
                info = "Sauna is off";
            }
            return $"{info}, temperature is {Temperature}, humidity is {Humidity}";
        }
        public void SetTemperature(int celsius)
        {
            // when sauna is on (HeaterOn=true)
            // temperature can be changed
            Temperature = celsius;
        }
        public void SetHumidity(int percent)
        {
            // when sauna is on (HeaterOn=true)
            // humidity can be changed
            Humidity = percent;
        }
        private int SetTemperature()
        {
            // helps to set temperature to 0
            Temperature = temperature;
            return Temperature;
        }
        private int SetHumidity()
        { 
            // helps to set humidity to 0
            Humidity = humidity;
            return Humidity;
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create new SaunaHeater-object
            SaunaHeater sauna = new SaunaHeater();
            sauna.HeaterOn = false;
            sauna.Temperature = 0;
            sauna.Humidity = 0;
            // show saunas condition
            Console.WriteLine($"{sauna.ShowSaunaInfo()}");
            // turn sauna on with variables and show sauna turned on with temperature=100 and humidity=50
            sauna.TurnSaunaOn(100, 50);
            Console.WriteLine($"{sauna.ShowSaunaInfo()}");
            //use methods to change temperature and humidity and see that variables have changed
            sauna.SetTemperature(85);
            sauna.SetHumidity(73);
            Console.WriteLine($"{sauna.ShowSaunaInfo()}");
            // turn sauna off and see that temperature and humidity have changed to 0
            sauna.TurnSaunaOff();
            Console.WriteLine($"{sauna.ShowSaunaInfo()}");
            // if sauna is turned off, changing temperature or humidity won't affect it
            sauna.SetTemperature(120);
            sauna.SetHumidity(10);
            Console.WriteLine($"{sauna.ShowSaunaInfo()}");
            // Creating another Object with different values
            // Trying to create sauna that is off with temperature and humidity other than 0
            // result to temperature and humidity defaulting to 0
            SaunaHeater höyrysauna = new SaunaHeater
            {
                HeaterOn = false,
                Humidity = 100,
                Temperature = 70
            };
            Console.WriteLine($"(Höyrysauna){höyrysauna.ShowSaunaInfo()}");
            //use default to turn sauna on with default values
            höyrysauna.TurnSaunaOnDefault();
            Console.WriteLine($"(Höyrysauna){höyrysauna.ShowSaunaInfo()}");
        }
    }
}
