using DynamicSun.Core.Exceptions;
using DynamicSun.Core.Interfaces;
using DynamicSun.Core.Models;
using DynamicSun.Core.Models.Enums;
using DynamicSun.Core.Models.SearchModels;
using DynamicSun.Entities;
using DynamicSun.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Core.Services
{
    public class WeatherByHoursService : IWeatherByHoursService
    {
        private readonly DataContext _context;
        private readonly IExelParserService _exelParser;


        public WeatherByHoursService(DataContext context, IExelParserService exelParser)
        {
            _context = context;
            _exelParser = exelParser;
        }

        public async Task<WeatherPage> GetWeather(WeatherSearchModel filter)
        {
            var queryWeather = _context.Set<WeatherByHours>()
                .AsNoTracking();
            if(filter.Month != 0)
                queryWeather = queryWeather.Where(x => x.Date.Month == filter.Month);
            if(filter.Year != 0)
                queryWeather = queryWeather.Where(x => x.Date.Year == filter.Year);
            
            switch (filter.SortContext)
            {
                case WeatherSortContext.None:
                    queryWeather = queryWeather.OrderBy(x => x.Date);
                    break;
                case WeatherSortContext.Temperature:
                    queryWeather = queryWeather.OrderBy(x => x.Temperature);
                    break;
                case WeatherSortContext.WindSpeed:
                    queryWeather = queryWeather.OrderBy(x => x.WindSpeed);
                    break;
                default:
                    queryWeather = queryWeather.OrderBy(x => x.Date);
                    break;
            }

            queryWeather = filter.Order == OrderSort.Ascending ? queryWeather : queryWeather.Reverse();
            var result = new WeatherPage()
            {
                Count = queryWeather.Count()
            };
            queryWeather = queryWeather
                .Skip(filter.Take * (filter.Page - 1))
                .Take(filter.Take);
            result.WeatherByHoursList = await queryWeather.ToListAsync();
            return result;
        }
        public async Task<string> SaveWeatherFromFiles(IFormFileCollection files)
        {

            for(int j = 0; j < files.Count; j++)
            {
                using var fileData = new MemoryStream();
                files[j].CopyTo(fileData);
                fileData.Position = 0;
                using (var workbook = new XSSFWorkbook(fileData))
                {
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        ISheet sheet = workbook.GetSheetAt(i);
                        var weather = new WeatherByHours();
                        var rowMap = await _exelParser.GetRowMap(sheet);
                        if (!rowMap.ContainsKey("Дата"))
                            throw new NotParseableException();

                        var list = await _exelParser.SetWeatherRow(sheet, rowMap);
                        _context.AddRange(list);
                        await _context.SaveChangesAsync();
                    }
                };

            }
            return "Погода была успешно сохранена";
        }

        public Task<List<int>> GetWeatherYears()
        {
            var query = _context.Set<WeatherByHours>().Select(x => x.Date.Year).Distinct().ToList();
            return Task.FromResult(query);
        }
    }
}
