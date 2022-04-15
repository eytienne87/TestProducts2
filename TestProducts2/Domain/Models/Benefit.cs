using Domain.Base;

namespace Domain.Models
{
    public class Benefit : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public virtual CategoryOfBenefit? Category { get; set; }
        public virtual ICollection<MarketSegment> MarketSegments { get; set; } = new HashSet<MarketSegment>();
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<BenefitDescription>? Descriptions { get; set; }
    }
}