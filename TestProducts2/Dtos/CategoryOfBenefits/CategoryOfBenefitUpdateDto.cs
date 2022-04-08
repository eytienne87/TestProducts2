using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class CategoryOfBenefitUpdateDto : BaseClass
    {
        public ICollection<CategoryOfBenefitDescriptionUpdateDto>? Descriptions { get; set; }
    }
}