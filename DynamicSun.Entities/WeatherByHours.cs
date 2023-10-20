using DynamicSun.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Entities
{
    public class WeatherByHours : BaseEntitie
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double AirHumidity { get; set; }
        public double Td { get; set; }
        public double ATMPressure { get; set; }
        public string WindDirection { get; set; }
        public double WindSpeed { get; set; }
        public double CloudCover { get; set; }
        public double H { get; set; }
        public double VV { get; set; } 
        public string WeatherEvent { get; set; }

        public WeatherByHours()
        {
            WindDirection = string.Empty;
            WeatherEvent = string.Empty;
        }


    }
}
