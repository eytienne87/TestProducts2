using Domain.Base;

namespace Domain.Models
{
    public class WarrantyTitle : BaseClass
    {
        public ICollection<WarrantyTitleDescription> Descriptions { get; set; }
    }
}