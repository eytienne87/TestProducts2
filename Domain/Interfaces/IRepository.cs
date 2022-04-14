using Domain.Base;
using System.Linq.Expressions;


namespace Domain.Interfaces
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
