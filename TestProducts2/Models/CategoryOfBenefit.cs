using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class CategoryOfBenefit : BaseClass
    {
        public ICollection<CategoryOfBenefitDescription> Descriptions { get; set; }
    }
}