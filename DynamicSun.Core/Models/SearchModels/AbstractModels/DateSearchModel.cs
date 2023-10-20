

namespace DynamicSun.Core.Models.SearchModels.AbstractModels
{
    public class DateSearchModel : Pagination
    {
        public int Month { get; set; } = 0;
        public int Year { get; set; } = 0;
    }
}
