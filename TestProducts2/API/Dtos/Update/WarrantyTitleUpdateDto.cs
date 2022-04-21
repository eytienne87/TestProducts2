using Domain.Base;

namespace API.Dtos.Update
{
    public class WarrantyTitleUpdateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public ICollection<WarrantyTitleDescriptionUpdateDto> Descriptions { get; set; } = new HashSet<WarrantyTitleDescriptionUpdateDto>();
    }
}
