using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class WarrantyTitleDescription
    {
        public int WarrantyTitleId { get; set; }
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }    
    }
}
