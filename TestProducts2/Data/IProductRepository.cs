using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Data
{
    public interface IProductRepository<T> where T : BaseClass
    {
        bool SaveChanges();
        IEnumerable<T> GetAll();
        T? GetById(int Id);
        bool Create(Product item);
        void JoinWarranty(T item);
        void JoinBenefit(Product item);
        void Update(T item);
        void Delete(T item);
    }
}
