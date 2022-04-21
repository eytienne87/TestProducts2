using Domain.Base;

namespace API.Dtos.Create
{
    public class MarketSegmentCreateDto : BaseClass
    {
        public ICollection<MarketSegmentDescriptionCreateDto>? Descriptions { get; set; }
    }
}