using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class CategoryOfBenefit : BaseClass
    {
        public virtual ICollection<CategoryOfBenefitDescription>? Descriptions { get; set; }

        public virtual HashSet<Benefit> Benefits { get; set; }  
    }
}