using System.ComponentModel.DataAnnotations.Schema;
using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Product : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        //public ICollection<ProductWarranty>? ProductWarranties { get; set; }
        public ICollection<ProductBenefit>? ProductBenefits { get; set; }
    }
}
