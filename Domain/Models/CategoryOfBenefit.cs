using Domain.Base;

namespace Domain.Models
{
    public class CategoryOfBenefit : BaseClass
    {
        public virtual ICollection<CategoryOfBenefitDescription>? Descriptions { get; set; }

        public virtual ICollection<Benefit>? Benefits { get; set; }
    }
}