

using System.Data.Entity;

namespace EvolentHealth.DAL
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }

        void Save();
    }
}
