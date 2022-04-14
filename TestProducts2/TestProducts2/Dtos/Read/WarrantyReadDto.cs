namespace TestProducts2.Dtos.Read
{
    public class WarrantyReadDto
    {
        public WarrantyTitleReadDto WarrantyTitle { get; set; } = new WarrantyTitleReadDto();
        public WarrantyLengthReadDto WarrantyLength { get; set; } = new WarrantyLengthReadDto();
        public WarrantyNotabeneReadDto? WarrantyNotabene { get; set; }
    }
}
