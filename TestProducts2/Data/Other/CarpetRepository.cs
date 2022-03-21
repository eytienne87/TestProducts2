using Microsoft.EntityFrameworkCore;
using TestProducts2.Models;

namespace TestProducts2.Data
{
    public class CarpetRepository : GenericRepository<Product>
    {
        public CarpetRepository(DbContext context) : base(context)
        {
        }
    }
}
