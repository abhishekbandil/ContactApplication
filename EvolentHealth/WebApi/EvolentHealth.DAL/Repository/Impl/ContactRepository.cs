using EvolentHealth.DAL.Repository;
using EvolentHealth.Model;

namespace EvolentHealth.DAL
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private IRepository<Contact> _unitOfWork;

        public ContactRepository() 
        {
            _unitOfWork = new Repository<Contact>();
        }
    }
}
