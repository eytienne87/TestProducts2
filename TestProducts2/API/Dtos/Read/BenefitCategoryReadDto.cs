namespace API.Dtos.Read
{
    public class BenefitCategoryReadDto
    {
        public int Id { get; set; }
        public virtual ICollection<CategoryOfBenefitDescriptionReadDto> Descriptions { get; set; } = new HashSet<CategoryOfBenefitDescriptionReadDto>();
    }
}
