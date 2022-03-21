using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class ProductCreateDto
    {
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public ICollection<ProductWarranty> ProductWarranties { get; set; }

    }
}