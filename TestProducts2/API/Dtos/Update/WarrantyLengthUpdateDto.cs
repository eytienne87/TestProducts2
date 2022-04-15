using Domain.Base;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyLengthUpdateDto : BaseClass
    {
        public ICollection<WarrantyLengthDescriptionUpdateDto> Descriptions { get; set; } = new HashSet<WarrantyLengthDescriptionUpdateDto>();
    }
}
