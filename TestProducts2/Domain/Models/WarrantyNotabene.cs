using Domain.Base;

namespace Domain.Models
{
    public class WarrantyNotabene : BaseClass
    {
        public ICollection<WarrantyNotabeneDescription> Descriptions { get; set; } = new HashSet<WarrantyNotabeneDescription>();
    }
}