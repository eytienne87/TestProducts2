using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Data
{
    public interface IRepository<T> where T : BaseClass
    {
        bool SaveChanges();
        IEnumerable<T> GetAll();
        T? GetById(int Id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
