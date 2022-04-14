using Domain.Base;

namespace Domain.Models
{
    public class MarketSegment : BaseClass
    {
        public string UrlName { get; set; } = string.Empty;
        public ICollection<MarketSegmentDescription>? Descriptions { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
    }
}