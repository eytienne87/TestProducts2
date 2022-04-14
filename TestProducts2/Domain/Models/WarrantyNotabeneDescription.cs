using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class WarrantyNotabeneDescription
    {
        public int WarrantyNotabeneId { get; set; }
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }
    }
}