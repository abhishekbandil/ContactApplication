
using EvolentHealth.DAL;
using System.Collections.Generic;
using System.IO;

namespace EvolentHealth.BAL.Contact
{
    public class ContactManager : IContactManager
    {
        private IRepository<Model.Contact> _contactRepository;

        public ContactManager()
        {
            _contactRepository = new Repository<Model.Contact>();
        }

        public IEnumerable<Model.Contact> GetContactList()
        {
            return _contactRepository.Get();
        }

        public void AddContact(Model.Contact con)
        {
            try
            {
                File.AppendAllText("D:\\temp.txt", "Add Contact");
                _contactRepository.Insert(con);
                _contactRepository.Save();
            }
            catch (System.Exception ex)
            {
                File.AppendAllText("D:\\temp.txt", ex.Message);
                throw;
            }
            
        }
    }
}
