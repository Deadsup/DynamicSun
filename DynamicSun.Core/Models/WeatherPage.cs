using DynamicSun.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Core.Models
{
    public class WeatherPage
    {
        public List<WeatherByHours> WeatherByHoursList { get; set; }
        public int Count { get; set; }
        public WeatherPage() 
        {
            WeatherByHoursList = new List<WeatherByHours>();
        }
    }
}
