using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class CategoryOfBenefitDescription
    {
        public int CategoryOfBenefitId { get; set; } 
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}