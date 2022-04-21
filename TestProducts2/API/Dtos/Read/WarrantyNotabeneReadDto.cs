namespace API.Dtos.Read
{
    public class WarrantyNotabeneReadDto
    {
        public int Id { get; set; }
        public ICollection<WarrantyNotabeneDescriptionReadDto> Descriptions { get; set; } = new HashSet<WarrantyNotabeneDescriptionReadDto>();
    }
}
