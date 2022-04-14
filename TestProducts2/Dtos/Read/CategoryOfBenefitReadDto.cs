namespace TestProducts2.Dtos.Read
{
    public class CategoryOfBenefitReadDto
    {
        public int Id { get; set; }
        public virtual ICollection<CategoryOfBenefitDescriptionReadDto> Descriptions { get; set; }
    }
}
