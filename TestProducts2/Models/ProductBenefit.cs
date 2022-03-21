using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class ProductBenefit
    {
        public int BenefitId { get; set; }
        public int ProductId { get; set; }
        public Benefit Benefit { get; set; }
        public Product Product { get; set; }
    }
}
