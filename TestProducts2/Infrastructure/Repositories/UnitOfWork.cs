using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void SaveChanges()
        {
            if (_sqlServerContext.ChangeTracker.HasChanges()) _sqlServerContext.SaveChanges();
        }
    }
}
