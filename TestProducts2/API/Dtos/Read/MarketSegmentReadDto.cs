namespace API.Dtos.Read
{
    public class MarketSegmentReadDto
    {
        public int Id { get; set; }
        public ICollection<MarketSegmentDescriptionReadDto> Descriptions { get; set; } = new HashSet<MarketSegmentDescriptionReadDto>();
    }
}
