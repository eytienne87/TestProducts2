using Domain.Base;

namespace Domain.Models
{
    public class WarrantyTitle : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public ICollection<WarrantyTitleDescription> Descriptions { get; set; } = new HashSet<WarrantyTitleDescription>();
    }
}