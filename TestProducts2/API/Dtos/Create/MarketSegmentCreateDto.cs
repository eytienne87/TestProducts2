using Domain.Base;

namespace TestProducts2.Dtos.Create
{
    public class MarketSegmentCreateDto : BaseClass
    {
        public ICollection<MarketSegmentDescriptionCreateDto>? Descriptions { get; set; }
    }
}