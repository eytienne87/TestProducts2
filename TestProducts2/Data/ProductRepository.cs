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
            return _context.Products
                .Include(p => p.Benefits)
                .Include(p => p.Warranties)
                    .ThenInclude(w => w.WarrantyTitle)
                .Include(p => p.Warranties)
                   .ThenInclude(w => w.WarrantyLength)
                .Include(p => p.Warranties)
                    .ThenInclude(w => w.WarrantyNotabene)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
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
                _context.Update(product);
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

