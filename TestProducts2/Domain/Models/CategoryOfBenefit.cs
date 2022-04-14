using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class CategoryOfBenefit : BaseClass
    {
        public virtual ICollection<CategoryOfBenefitDescription>? Descriptions { get; set; }

        public virtual ICollection<Benefit>? Benefits { get; set; }
    }
}