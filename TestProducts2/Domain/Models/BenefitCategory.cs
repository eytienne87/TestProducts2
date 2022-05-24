using Domain.Base;

namespace Domain.Models
{
    public class BenefitCategory : BaseClass
    {
        public virtual ICollection<BenefitCategoryDescription>? Descriptions { get; set; }

        public virtual ICollection<Benefit>? Benefits { get; set; }
    }
}