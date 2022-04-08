using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class CategoryOfBenefitCreateDto : BaseClass
    {
        public ICollection<CategoryOfBenefitDescriptionCreateDto>? Descriptions { get; set; }
    }
}