using DynamicSun.Core.Interfaces;
using DynamicSun.Core.Models.SearchModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json;

namespace DynamicSun.Controllers
{
    [Route("api/weatherByDate")]
    [ApiController]
    public class WeatherByHoursController : Controller
    {
        private readonly IWeatherByHoursService _weatherByHours;
        public WeatherByHoursController(IWeatherByHoursService weatherByHours)
        {
            _weatherByHours = weatherByHours;
        }


        [HttpGet]
        [Route("years")]
        public async Task<IActionResult> GetWeatherYears()
        {
            var json = Json(await _weatherByHours.GetWeatherYears());
            json.StatusCode = 200;
            return Ok(json);
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery] WeatherSearchModel filter)
        {
            var json = Json(await _weatherByHours.GetWeather(filter));
            json.StatusCode = 200;
            return Ok(json);
        }

        [HttpPost]
        [Route("uploadExel")]
        public async Task<IActionResult> UploadExel()
        {
            var files = Request.Form.Files;
            var result = _weatherByHours.SaveWeatherFromFiles(files);
            var json = Json(await result);
            json.StatusCode = 200;
            return json;
        }
    }
}
