using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IColorNameRepository
    {
        IQueryable<ColorName> Get(Expression<Func<ColorName, bool>>? filter = null);
        public IEnumerable<ColorName> GetAll();
        bool SaveChanges();
    }
}
