using Domain.Base;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseClass
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>? GetByIdAsync(int Id);
        Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>>? filter = null);
        void BulkDelete(List<T> items);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
