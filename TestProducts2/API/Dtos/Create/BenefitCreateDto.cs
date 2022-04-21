using Domain.Base;

namespace API.Dtos.Create
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