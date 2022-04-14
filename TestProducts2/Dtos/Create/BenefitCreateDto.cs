using TestProducts2.Entities;

namespace TestProducts2.Dtos.Create
{
    public class BenefitCreateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty; 
        public HashSet<BenefitDescriptionCreateDto>? Descriptions { get; set; }
        public HashSet<MarketSegmentCreateDto>? MarketSegments { get; set; }
        public CategoryOfBenefitCreateDto? Category { get; set; }
        public int CategoryId { get; set; }
    }
}