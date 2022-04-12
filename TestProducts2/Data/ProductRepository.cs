using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestProducts2.Entities;
using TestProducts2.Models;


namespace TestProducts2.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;

        public ProductRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Product? GetById(int Id)
        {
            var product = _context.Products
                .Include(p => p.Benefits)
                .Include(p => p.Warranties)
                    .ThenInclude(w => w.WarrantyTitle)
                .Include(p => p.Warranties)
                   .ThenInclude(w => w.WarrantyLength)
                .Include(p => p.Warranties)
                    .ThenInclude(w => w.WarrantyNotabene)
                .FirstOrDefault(p => p.Id == Id);
            _context.Entry(product.Benefits).State = EntityState.Detached;
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.Benefits)
                .Include(p => p.Warranties)
                   .ThenInclude(w => w.WarrantyTitle)
                .Include(p => p.Warranties)
                   .ThenInclude(w => w.WarrantyLength)
                .Include(p => p.Warranties)
                   .ThenInclude(w => w.WarrantyNotabene)
                .ToList();

        }

        public void Update(Product product)
        {
            //_context.ChangeTracker
            //.TrackGraph(product, e =>
            //{
            //    if (e.Entry.IsKeySet)
            //    {
            //        e.Entry.State = EntityState.Modified;
            //    }
            //    else
            //    {
            //        e.Entry.State = EntityState.Added;
            //    }
            //});
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.Entry(product.Benefits).State = EntityState.Modified;
            //_context.Products.Update(product);
        }

        public bool Create(Product product)
        {
            _context.Products.Add(product);

            return SaveChanges();
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Remove(product);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

