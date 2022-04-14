namespace TestProducts2.Dtos.Read
{
    public class WarrantyTitleReadDto
    {
        public int Id { get; set; }
        public ICollection<WarrantyTitleDescriptionReadDto> Descriptions { get; set; }
    }
}
