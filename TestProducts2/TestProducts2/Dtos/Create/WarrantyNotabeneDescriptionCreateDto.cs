using Domain.Shared;

namespace TestProducts2.Dtos.Create
{
    public class WarrantyNotabeneDescriptionCreateDto
    {
        public string Description { get; set; } = string.Empty;   
        public LanguageClass Language { get; set; }   
    }
}
