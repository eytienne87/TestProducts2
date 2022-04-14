using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class MarketSegment : BaseClass
    {
        public string UrlName { get; set; } = string.Empty;
        public ICollection<MarketSegmentDescription>? Descriptions { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
    }
}