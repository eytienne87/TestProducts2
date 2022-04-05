using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class BenefitReadDto
    {
        public int Id { get; set; } 
        public ICollection<BenefitDescriptionReadDto> Descriptions { get; set; }
    }
}
