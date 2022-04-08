using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class MarketSegmentReadDto
    {
        public int Id { get; set; } 
        public ICollection<MarketSegmentDescriptionReadDto> Descriptions { get; set; }
    }
}
