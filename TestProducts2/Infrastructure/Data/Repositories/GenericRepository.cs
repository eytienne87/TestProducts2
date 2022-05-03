using Domain.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseClass
    {
        private readonly DbContext _context;

        private readonly DbSet<T> table;

        public GenericRepository(DbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Create(T item)
        {
            table.Add(item);
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            table.Remove(item);
        }
        public async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = table;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public void BulkDelete(List<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            table.RemoveRange(items);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await table.FirstOrDefaultAsync(q => q.Id == Id);
        }

        public void Update(T item)
        {
            _context.Update(item);
        }
    }
}


