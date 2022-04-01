using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Data
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
