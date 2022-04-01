namespace TestProducts2.Dtos
{
    public class WarrantyTitleReadDto
    {
        public int Id { get; set; } 
        public ICollection<WarrantyTitleDescriptionReadDto> Descriptions { get; set; }
    }
}
