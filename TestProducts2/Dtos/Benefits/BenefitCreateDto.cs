using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class BenefitCreateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty; 
        public ICollection<BenefitDescriptionCreateDto>? Descriptions { get; set; }
        public ICollection<MarketSegmentCreateDto>? MarketSegments { get; set; }
        public CategoryOfBenefitCreateDto? Category { get; set; }
    }
}