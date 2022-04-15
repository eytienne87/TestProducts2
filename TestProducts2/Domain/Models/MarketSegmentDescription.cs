using Domain.Shared;

namespace Domain.Models
{
    public class MarketSegmentDescription
    {
        public int MarketSegmentId { get; set; }
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}