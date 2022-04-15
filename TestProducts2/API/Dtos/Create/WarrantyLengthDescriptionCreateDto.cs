using Domain.Shared;

namespace TestProducts2.Dtos.Create
{
    public class WarrantyLengthDescriptionCreateDto
    {
        public LanguageClass Language { get; set; }   
        public string Description { get; set; } = string.Empty;   
    }
}
