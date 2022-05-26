using Domain.Base;

namespace Domain.Models
{
    public class Product : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string BackingCode { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public string MarketingProgram { get; set; } = string.Empty;
        public decimal Width { get; set; } = decimal.Zero;
        public virtual HashSet<Benefit> Benefits { get; set; } = new HashSet<Benefit>();
        public virtual HashSet<Warranty> Warranties { get; set; } = new HashSet<Warranty>();
        public virtual AbrasionResistance? Abrasion { get; set; } 
    }
}