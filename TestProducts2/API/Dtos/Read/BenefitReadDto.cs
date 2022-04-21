namespace API.Dtos.Read
{
    public class BenefitReadDto
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public virtual CategoryOfBenefitReadDto? Category { get; set; }
        public virtual ICollection<MarketSegmentReadDto>? MarketSegments { get; set; }
        public virtual ICollection<BenefitDescriptionReadDto> Descriptions { get; set; } = new HashSet<BenefitDescriptionReadDto>();
    }
}
