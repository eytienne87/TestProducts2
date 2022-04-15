using Domain.Shared;

namespace Domain.Models
{
    public class BenefitDescription
    {
        public int BenefitId { get; set; }
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}