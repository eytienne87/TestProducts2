using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class MarketSegmentUpdateDto : BaseClass
    {
        public ICollection<MarketSegmentDescriptionUpdateDto>? Descriptions { get; set; }
    }
}