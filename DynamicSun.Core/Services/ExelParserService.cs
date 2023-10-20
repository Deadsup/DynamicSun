using DynamicSun.Core.Interfaces;
using DynamicSun.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Core.Services
{
    public class ExelParserService : IExelParserService
    {
        public Task<Dictionary<string, int>> GetRowMap(ISheet sheet)
        {
            Dictionary<string, int> rowMap = new Dictionary<string, int>();
            var row = sheet.GetRow(2);
            for (int i = 0; i < row.LastCellNum; i++)
            {
                var key = ParseCellText(row.GetCell(i));
                rowMap.TryAdd(key.TrimEnd().TrimStart(), i);
            }
            return Task.FromResult(rowMap);
        }

        public async Task<WeatherByHours[]> SetWeatherRow(ISheet sheet, Dictionary<string, int> map)
        {
            var weatherList = new WeatherByHours[sheet.LastRowNum - 4];
            for (int i = 4; i < sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                var weather = new WeatherByHours();
                weather.Temperature = await GetCellValueForNumeric(row.GetCell(map["Т"]));
                weather.AirHumidity = await GetCellValueForNumeric(row.GetCell(map["Отн. влажность"]));
                weather.Date = DateTime.Parse($"{row.GetCell(map["Дата"]).StringCellValue} {row.GetCell(map["Время"]).StringCellValue}");
                weather.Td = await GetCellValueForNumeric(row.GetCell(map["Td"])); 
                weather.ATMPressure = await GetCellValueForNumeric(row.GetCell(map["Атм. давление,"]));
                weather.WindDirection = ParseCellText(row.GetCell(map["Направление"]));
                weather.WindSpeed = await GetCellValueForNumeric(row.GetCell(map["Скорость"])); 
                weather.CloudCover = await GetCellValueForNumeric(row.GetCell(map["Облачность,"]));
                weather.H = await GetCellValueForNumeric(row.GetCell(map["h"]));
                weather.WeatherEvent = ParseCellText(row.GetCell(map["Погодные явления"]));
                weather.VV = await GetCellValueForNumeric(row.GetCell(map["VV"]));
                weatherList[i - 4] = weather;
            }
            return weatherList;

        }

        public string ParseCellText(ICell? cell)
        {
            if (cell is null)
                return "";

            if (cell.CellType != CellType.String)
                cell.SetCellType(CellType.String);

            return cell.StringCellValue;
        }

        public Task<double> GetCellValueForNumeric(ICell? cell)
        {
            var value = 0.0;
            if (cell is null)
                return Task.FromResult(value);

            if (cell.CellType == CellType.Numeric)
            {
                value = cell.NumericCellValue;
            }
            else
            {
                var valueString = cell.ToString();
                double.TryParse(valueString, out value);
            }

            return Task.FromResult(value);
        }

    }
}
