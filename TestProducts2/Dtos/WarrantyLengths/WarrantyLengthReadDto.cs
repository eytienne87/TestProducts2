namespace TestProducts2.Dtos
{
    public class WarrantyLengthReadDto
    {
        public int Id { get; set; } 
        public ICollection<WarrantyLengthDescriptionReadDto> Descriptions { get; set; }
    }
}
