using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class OfBenefitsCategory : BaseClass
    {
        public ICollection<OfBenefitsCategoryDescription> Descriptions { get; set; }
    }
}