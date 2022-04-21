using Domain.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
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

        public bool Create(T item)
        {
            table.Add(item);

            return SaveChanges();
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            table.Remove(item);

        }
        public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null)
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

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T? GetById(int Id)
        {
            return table.FirstOrDefault(q => q.Id == Id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool Update(T item)
        {
            _context.Update(item);

            return SaveChanges();
        }
    }
}


