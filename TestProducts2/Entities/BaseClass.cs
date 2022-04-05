namespace TestProducts2.Entities
{
    public class BaseClass
    {
        public int Id { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
