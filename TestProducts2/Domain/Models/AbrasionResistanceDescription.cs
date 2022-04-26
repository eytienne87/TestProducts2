using Domain.Shared;

namespace Domain.Models
{
    public class AbrasionResistanceDescription
    {
        public int AbrasionResistanceId { get; set; }
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}