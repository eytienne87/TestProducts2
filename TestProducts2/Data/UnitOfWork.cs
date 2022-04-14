﻿

namespace TestProducts2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Save()
        {
            if (_sqlServerContext.ChangeTracker.HasChanges()) _sqlServerContext.SaveChanges();
        }
    }
}
