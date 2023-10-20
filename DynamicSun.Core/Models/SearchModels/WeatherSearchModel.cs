using DynamicSun.Core.Models.Enums;
using DynamicSun.Core.Models.SearchModels.AbstractModels;

namespace DynamicSun.Core.Models.SearchModels
{
    public class WeatherSearchModel : DateSearchModel
    {
        public OrderSort Order {  get; set; }
        public WeatherSortContext SortContext { get; set; }
    }
}
