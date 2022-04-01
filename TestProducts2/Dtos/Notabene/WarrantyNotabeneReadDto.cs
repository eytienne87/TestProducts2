namespace TestProducts2.Dtos
{
    public class WarrantyNotabeneReadDto
    {
        public int Id { get; set; }
        public ICollection<WarrantyNotabeneDescriptionReadDto> Descriptions { get; set; }
    }
}
