using Domain.Base;

namespace API.Dtos.Update
{
    public class ProductUpdateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public HashSet<BenefitUpdateDto>? Benefits { get; set; }
        public HashSet<WarrantyUpdateDto>? Warranties { get; set; }
        public AbrasionResistanceUpdateDto? Abrasion { get; set; }
        public int AbrasionId { get; set; }
    }
}