using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class ProductCreateDto
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public ICollection<BenefitCreateDto>? Benefits { get; set; }    
        public ICollection<WarrantyCreateDto>? Warranties { get; set; }    
    }
}