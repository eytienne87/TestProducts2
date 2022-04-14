using Domain.Base;


namespace TestProducts2.Dtos.Update
{
    public class CategoryOfBenefitUpdateDto : BaseClass
    {
        public ICollection<CategoryOfBenefitDescriptionUpdateDto>? Descriptions { get; set; }
    }
}