using TestProducts2.Entities;


namespace TestProducts2.Domain.Repositories
{
    public interface IProductRepository
    {
        bool SaveChanges();
        IEnumerable<Product> GetAll();
        bool Create(Product product);
        Product? GetById(int Id);
        void Update(Product product);
        void Delete(Product product);
    }
}
