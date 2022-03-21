using System.ComponentModel.DataAnnotations.Schema;
using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class ProductWarranty : BaseClass
    {
        public int ProductId { get; set; }
        public int WarrantyTitleId { get; set; }
        public int WarrantyLengthId { get; set; }
        public int? WarrantyNotaBeneId { get; set; }
        public Product? Product { get; set; }
        public WarrantyTitle? WarrantyTitle { get; set; }
        public WarrantyLength? WarrantyLength { get; set; }
        public WarrantyNotabene? WarrantyNotabene { get; set; }
    }
}
