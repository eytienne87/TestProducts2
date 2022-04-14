using TestProducts2.Entities;

namespace TestProducts2.Domain.Models
{
    public class BenefitDescription
    {
        public int BenefitId { get; set; }
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}