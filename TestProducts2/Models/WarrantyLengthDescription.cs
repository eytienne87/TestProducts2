using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class WarrantyLengthDescription
    {
        public int WarrantyLengthId { get; set; }
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }
    }
}
