using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            if (_context.ChangeTracker.HasChanges()) 
               await _context.SaveChangesAsync();
        }
    }
}
