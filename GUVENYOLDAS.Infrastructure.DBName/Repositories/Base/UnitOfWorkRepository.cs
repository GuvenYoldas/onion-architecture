using GUVENYOLDAS.Data.DBName;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;

namespace GUVENYOLDAS.Infrastructure.DBName.Repositories.Base
{
    public sealed class UnitOfWorkRepository : IUnitOfWork
    {
        // private DbContext _context;
        private DBNameDbContext _context;

        public UnitOfWorkRepository(DBNameDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task SaveAsync()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        #region IDisposable Support
        private bool disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
