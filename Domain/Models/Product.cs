using Domain.Base;

namespace Domain.Models
{
    public class Product : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public virtual HashSet<Benefit> Benefits { get; set; } = new HashSet<Benefit>();
        public virtual HashSet<Warranty> Warranties { get; set; } = new HashSet<Warranty>();
    }
}