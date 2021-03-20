
using EvolentHealth.DAL;
using System.Data.Entity;

namespace EvolentHealth.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public EvolentHealthDBContext _context;

        public UnitOfWork()
        {
            _context = new EvolentHealthDBContext();
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
