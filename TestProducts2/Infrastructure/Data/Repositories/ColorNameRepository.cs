using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class ColorNameRepository : IColorNameRepository
    {
        private readonly PostgresContext _context;

        public ColorNameRepository(PostgresContext context)
        {
            _context = context;
        }
        public IQueryable<ColorName> Get(Expression<Func<ColorName, bool>>? filter = null)
        {
            IQueryable<ColorName> query = _context.ColorNames;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public IEnumerable<ColorName> GetAll()
        {
            return _context.ColorNames.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}