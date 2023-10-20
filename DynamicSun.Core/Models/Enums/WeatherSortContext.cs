using System.ComponentModel;

namespace DynamicSun.Core.Models.Enums
{
    public enum WeatherSortContext
    {
        [Description("NoSort")]
        None,
        [Description("Date")]
        Date,
        [Description("WindSpeed")]
        WindSpeed,
        [Description("Temperature")]
        Temperature

    }
}
