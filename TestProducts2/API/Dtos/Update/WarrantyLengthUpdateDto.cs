using Domain.Base;

namespace API.Dtos.Update
{
    public class WarrantyLengthUpdateDto : BaseClass
    {
        public ICollection<WarrantyLengthDescriptionUpdateDto> Descriptions { get; set; } = new HashSet<WarrantyLengthDescriptionUpdateDto>();
    }
}
