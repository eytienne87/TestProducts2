using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class MarketSegmentCreateDto : BaseClass
    {
        public ICollection<MarketSegmentDescriptionCreateDto>? Descriptions { get; set; }
    }
}