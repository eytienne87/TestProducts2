namespace TestProducts2.Dtos
{
    public class WarrantyTitleCreateDto
    {
        public ICollection<WarrantyTitleDescriptionCreateDto> Descriptions { get; set; }   
    }
}
