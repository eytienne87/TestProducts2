using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class ProductUpdateDto
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public HashSet<BenefitUpdateDto>? Benefits { get; set; }    
        public HashSet<WarrantyUpdateDto>? Warranties { get; set; }    
    }
}