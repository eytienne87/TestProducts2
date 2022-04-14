using Domain.Base;

namespace Domain.Models
{
    public class WarrantyLength : BaseClass
    {
        public ICollection<WarrantyLengthDescription> Descriptions { get; set; }
    }
}