using TestProducts2.Entities;

namespace TestProducts2.Dtos.Create
{
    public class CategoryOfBenefitCreateDto : BaseClass
    {
        public HashSet<CategoryOfBenefitDescriptionCreateDto>? Descriptions { get; set; }
    }
}