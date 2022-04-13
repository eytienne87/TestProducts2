using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
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