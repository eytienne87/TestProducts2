using Domain.Base;


namespace API.Dtos.Update
{
    public class CategoryOfBenefitUpdateDto : BaseClass
    {
        public ICollection<CategoryOfBenefitDescriptionUpdateDto>? Descriptions { get; set; }
    }
}