using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class MarketSegmentDescription
    {
        public int MarketSegmentId { get; set; }
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}