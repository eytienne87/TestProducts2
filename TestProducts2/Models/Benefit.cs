using System.Text.Json.Serialization;
using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Benefit : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public virtual CategoryOfBenefit? Category { get; set; }
        public virtual ICollection<MarketSegment>? MarketSegments { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<BenefitDescription>? Descriptions { get; set; }
    }
}
