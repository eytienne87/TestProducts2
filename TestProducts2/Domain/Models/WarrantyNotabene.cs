using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class WarrantyNotabene : BaseClass
    {
        public ICollection<WarrantyNotabeneDescription> Descriptions { get; set; }
    }
}