using System.Text.Json.Serialization;
using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Benefit : BaseClass
    {
        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<BenefitDescription>? Descriptions { get; set; }
    }
}
