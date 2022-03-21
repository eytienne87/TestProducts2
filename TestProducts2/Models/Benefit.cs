using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Benefit : BaseClass
    {
        public ICollection<ProductBenefit> ProductBenefits { get; set; }
    }
}
