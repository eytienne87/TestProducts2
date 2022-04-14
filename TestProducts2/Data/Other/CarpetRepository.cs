using Microsoft.EntityFrameworkCore;


namespace TestProducts2.Data.Other
{
    public class CarpetRepository : GenericRepository<Product>
    {
        public CarpetRepository(DbContext context) : base(context)
        {
        }
    }
}
