using TestProducts2.Entities;

namespace TestProducts2.Dtos
{
    public class WarrantyNotabeneDescriptionCreateDto
    {
        public string Description { get; set; } = string.Empty;   
        public LanguageClass Language { get; set; }   
    }
}
