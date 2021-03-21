
using EvolentHealth.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace EvolentHealth.BAL.Contact
{
    public class ContactManager : IContactManager
    {
        private IRepository<Model.Contact> _contactRepository;

        public ContactManager(IRepository<Model.Contact> contactRepository)
        {
            _contactRepository = contactRepository;// new Repository<Model.Contact>();
        }

        public IEnumerable<Model.Contact> GetContactList()
        {
            return _contactRepository.Get();
        }

        public Model.Contact GetContact(int id)
        {
            return _contactRepository.Get(c => c.Id == id).FirstOrDefault();
        }

        public bool DeleteContact(int id)
        {
            _contactRepository.Delete(id);
            _contactRepository.Save();
            return true;
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

        public bool EditContact(Model.Contact con)
        {
            var contact = _contactRepository.Get(c => c.Id == con.Id).FirstOrDefault();
            contact.FirstName = con.FirstName;
            contact.LastName = con.LastName;
            contact.Email = con.Email;

            _contactRepository.Update(contact);
            _contactRepository.Save();
            return true;
        }
    }
}
