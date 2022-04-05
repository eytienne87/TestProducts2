using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class ProductUpdateDto
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public ICollection<BenefitUpdateDto>? Benefits { get; set; }    
        public ICollection<WarrantyUpdateDto>? Warranties { get; set; }    
    }
}