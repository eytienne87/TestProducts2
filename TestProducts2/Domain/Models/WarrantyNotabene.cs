using Domain.Base;

namespace Domain.Models
{
    public class WarrantyNotabene : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public ICollection<WarrantyNotabeneDescription> Descriptions { get; set; } = new HashSet<WarrantyNotabeneDescription>();
    }
}