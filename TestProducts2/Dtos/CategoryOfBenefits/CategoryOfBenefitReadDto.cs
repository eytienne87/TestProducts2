using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class CategoryOfBenefitReadDto
    {
        public int Id { get; set; } 
        public ICollection<CategoryOfBenefitDescriptionReadDto> Descriptions { get; set; }
    }
}
