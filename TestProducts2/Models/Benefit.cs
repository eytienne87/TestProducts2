using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Benefit : BaseClass
    {
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<BenefitDescription>? Descriptions { get; set; }
    }
}
