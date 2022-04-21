using Domain.Base;

namespace API.Dtos.Update
{
    public class WarrantyNotabeneUpdateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public ICollection<WarrantyNotabeneDescriptionUpdateDto> Descriptions { get; set; } = new HashSet<WarrantyNotabeneDescriptionUpdateDto>();
    }
}
