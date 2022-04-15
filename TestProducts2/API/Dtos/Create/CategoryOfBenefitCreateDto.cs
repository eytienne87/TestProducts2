using Domain.Base;

namespace TestProducts2.Dtos.Create
{
    public class CategoryOfBenefitCreateDto : BaseClass
    {
        public HashSet<CategoryOfBenefitDescriptionCreateDto>? Descriptions { get; set; }
    }
}