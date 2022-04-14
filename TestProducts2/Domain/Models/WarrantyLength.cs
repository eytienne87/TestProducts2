using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class WarrantyLength : BaseClass
    {
        public ICollection<WarrantyLengthDescription> Descriptions { get; set; }
    }
}