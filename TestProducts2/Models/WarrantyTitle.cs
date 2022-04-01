using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class WarrantyTitle : BaseClass
    {
        public ICollection<WarrantyTitleDescription> Descriptions { get; set; }  
    }
}
