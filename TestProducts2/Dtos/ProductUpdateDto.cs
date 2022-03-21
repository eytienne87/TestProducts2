using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class ProductUpdateDto
    {
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public ICollection<ProductWarranty>? ProductWarranties { get; set; }
    }
}