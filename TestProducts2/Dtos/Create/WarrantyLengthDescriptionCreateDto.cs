using TestProducts2.Entities;

namespace TestProducts2.Dtos.Create
{
    public class WarrantyLengthDescriptionCreateDto
    {
        public LanguageClass Language { get; set; }   
        public string Description { get; set; } = string.Empty;   
    }
}
