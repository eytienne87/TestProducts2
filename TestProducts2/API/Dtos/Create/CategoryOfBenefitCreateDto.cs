using Domain.Base;

namespace API.Dtos.Create
{
    public class CategoryOfBenefitCreateDto : BaseClass
    {
        public HashSet<CategoryOfBenefitDescriptionCreateDto>? Descriptions { get; set; }
    }
}