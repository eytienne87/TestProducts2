using Domain.Shared;

namespace Domain.Models
{
    public class WarrantyLengthDescription
    {
        public int WarrantyLengthId { get; set; }
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }
    }
}