using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestProducts2.Entities;
using TestProducts2.Models;


namespace TestProducts2.Data
{
    public class ProductRepository<T> : IProductRepository<T> where T : BaseClass
    {
        private readonly DbContext _context;

        private readonly DbSet<T> table;

        public ProductRepository(DbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public bool Create(Product item)
        {
            //JoinWarranty(item);
            JoinBenefit(item);

            _context.Add(item);

            return SaveChanges();
        }

        public void JoinWarranty(T item)
        {
            //foreach(var warranty in item.ProductWarranties)
            //{
            //    Warranty warrantyEntity = _context.Set<Warranty>().Where(w => w.Id == warranty.Id).FirstOrDefault();
            //    var productWarranty = new ProductWarranty()
            //    {
            //        Product = item,
            //        Warranty = warrantyEntity
            //    };

            //    _context.Add(productWarranty);
            //}
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

        public void JoinBenefit(Product item)
        {
            foreach (var benefit in item.ProductBenefits)
            {
                Benefit benefitEntity = _context.Set<Benefit>().Where(w => w.Id == benefit.BenefitId).FirstOrDefault();
                var productBenefit = new ProductBenefit()
                {
                    Product = item,
                    Benefit = benefitEntity
                };

                _context.Add(productBenefit);
            }
        }
    }
}


