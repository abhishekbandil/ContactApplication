
using System.Collections.Generic;

namespace EvolentHealth.BAL.Contact
{
   public interface IContactManager
    {
        IEnumerable<Model.Contact> GetContactList();

       void AddContact(Model.Contact con);

        Model.Contact GetContact(int id);

        bool DeleteContact(int id);

        bool EditContact(Model.Contact con);
    }
}
