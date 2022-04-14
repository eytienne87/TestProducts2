using System.Linq.Expressions;
using TestProducts2.Entities;


namespace TestProducts2.Domain.Repositories
{
    public interface IRepository<T> where T : BaseClass
    {
        bool SaveChanges();
        IEnumerable<T> GetAll();
        T? GetById(int Id);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
        void BulkDelete(List<T> items);
        bool Create(T item);
        bool Update(T item);
        void Delete(T item);
    }
}
