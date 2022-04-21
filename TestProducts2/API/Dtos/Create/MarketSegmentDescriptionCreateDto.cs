using Domain.Shared;

namespace API.Dtos.Create
{
    public class MarketSegmentDescriptionCreateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}