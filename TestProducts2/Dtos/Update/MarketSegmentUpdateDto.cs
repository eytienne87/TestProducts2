using TestProducts2.Entities;


namespace TestProducts2.Dtos.Update
{
    public class MarketSegmentUpdateDto : BaseClass
    {
        public ICollection<MarketSegmentDescriptionUpdateDto>? Descriptions { get; set; }
    }
}