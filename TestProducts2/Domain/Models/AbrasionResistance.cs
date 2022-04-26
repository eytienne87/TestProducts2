using Domain.Base;

namespace Domain.Models
{
    public class AbrasionResistance : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public virtual ICollection<AbrasionResistanceDescription> Descriptions { get; set; } = new HashSet<AbrasionResistanceDescription>();    
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();    
    }
}