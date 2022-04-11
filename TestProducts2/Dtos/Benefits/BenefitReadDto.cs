using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class BenefitReadDto
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public virtual CategoryOfBenefitReadDto? Category { get; set; }
        public virtual ICollection<MarketSegmentReadDto>? MarketSegments { get; set; }
        public ICollection<BenefitDescriptionReadDto> Descriptions { get; set; }
    }
}
