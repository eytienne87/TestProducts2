using TestProducts2.Entities;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyLengthUpdateDto : BaseClass
    {
        public ICollection<WarrantyLengthDescriptionUpdateDto> Descriptions { get; set; }
    }
}
