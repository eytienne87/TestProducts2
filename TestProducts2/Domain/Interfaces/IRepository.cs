using Domain.Base;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseClass
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int Id);
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>>? filter = null);
        Task<T?> FindOne(Expression<Func<T, bool>>? filter = null);
        void Create(T item);
        void Update(T item);
        void BulkDelete(List<T> items);
        void Delete(T item);
    }
}
