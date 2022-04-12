using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class BenefitCreateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty; 
        public HashSet<BenefitDescriptionCreateDto>? Descriptions { get; set; }
        public HashSet<MarketSegmentCreateDto>? MarketSegments { get; set; }
        public CategoryOfBenefitCreateDto? Category { get; set; }
    }
}