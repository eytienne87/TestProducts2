using Domain.Base;


namespace API.Dtos.Update
{
    public class MarketSegmentUpdateDto : BaseClass
    {
        public ICollection<MarketSegmentDescriptionUpdateDto>? Descriptions { get; set; }
    }
}