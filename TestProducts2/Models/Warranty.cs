using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Warranty : BaseClass
    {
        public WarrantyTitle WarrantyTitle { get; set; } = default!;
        public WarrantyLength WarrantyLength { get; set; } = default!;
        public WarrantyNotabene? WarrantyNotabene { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }  
    }
}
