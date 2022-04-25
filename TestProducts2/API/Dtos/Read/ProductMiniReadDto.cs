using Domain.Base;

namespace API.Dtos.Read
{
    public class ProductMiniReadDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public virtual ICollection<BenefitReadDto> Benefits { get; set; } = new HashSet<BenefitReadDto>();
    }
}