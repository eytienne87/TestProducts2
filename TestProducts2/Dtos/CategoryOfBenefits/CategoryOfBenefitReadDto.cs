using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class CategoryOfBenefitReadDto
    {
        public int Id { get; set; } 
        public virtual ICollection<CategoryOfBenefitDescriptionReadDto>? Descriptions { get; set; }
    }
}
