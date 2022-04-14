using TestProducts2.Entities;


namespace TestProducts2.Dtos.Update
{
    public class BenefitUpdateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public HashSet<BenefitDescriptionUpdateDto>? Descriptions { get; set; }
        public HashSet<MarketSegmentUpdateDto>? MarketSegments { get; set; }
        public int CategoryId { get; set; }
        public CategoryOfBenefitUpdateDto? Category { get; set; }
    }
}