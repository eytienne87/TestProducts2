using Domain.Base;

namespace Domain.Models
{
    public class Warranty : BaseClass
    {
        public WarrantyTitle WarrantyTitle { get; set; } = default!;
        public WarrantyLength WarrantyLength { get; set; } = default!;
        public WarrantyNotabene? WarrantyNotabene { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}