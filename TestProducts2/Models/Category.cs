using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class Category : BaseClass
    {
        public ICollection<CategoryDescription> Descriptions { get; set; }
    }
}