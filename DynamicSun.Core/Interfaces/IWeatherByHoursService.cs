using DynamicSun.Core.Models;
using DynamicSun.Core.Models.SearchModels;
using DynamicSun.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Core.Interfaces
{
    public interface IWeatherByHoursService
    {
        Task<WeatherPage> GetWeather(WeatherSearchModel filter);
        Task<string> SaveWeatherFromFiles(IFormFileCollection file);
        Task<List<int>> GetWeatherYears();
    }
}
