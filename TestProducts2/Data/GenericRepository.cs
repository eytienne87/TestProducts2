using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestProducts2.Entities;
using TestProducts2.Models;


namespace TestProducts2.Data
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
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
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

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T? GetById(int Id)
        {
            return table.Find(Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(T item)
        {
            //Nothing
        }

        //public bool CreateCarpet(int warrantyId, T item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}


