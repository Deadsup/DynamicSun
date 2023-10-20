using DynamicSun.Entities;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Core.Interfaces
{
    public interface IExelParserService
    {
        Task<Dictionary<string, int>> GetRowMap(ISheet sheet);
        Task<WeatherByHours[]> SetWeatherRow(ISheet sheet, Dictionary<string, int> map);
        string ParseCellText(ICell? cell);
        Task<double> GetCellValueForNumeric(ICell? cell);
    }
}
