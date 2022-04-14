namespace TestProducts2.Dtos.Read
{
    public class ProductReadDto
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public ICollection<BenefitReadDto>? Benefits { get; set; }
        public ICollection<WarrantyReadDto>? Warranties { get; set; }
    }
}
