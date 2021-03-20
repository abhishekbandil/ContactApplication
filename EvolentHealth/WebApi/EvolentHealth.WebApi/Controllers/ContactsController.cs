using EvolentHealth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EvolentHealth.BAL.Contact;
using Newtonsoft.Json;

namespace EvolentHealth.WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        public IContactManager _contactManager;

        public ContactsController()
        {
            _contactManager = new ContactManager();
        }

        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {

            var json = JsonConvert.SerializeObject(_contactManager.GetContactList().FirstOrDefault());

            return _contactManager.GetContactList();
        }

        // GET: api/Contact/5
        public Contact Get(int id)
        {
          //  return "value";
            return null;
        }

        // POST: api/Contact
        public void Post([FromBody]Contact value)
        {

            value = new Contact { FirstName = "Abhishek",Id = Guid.NewGuid(), LastName="bandil" };

            _contactManager.AddContact(value);
        }

        // DELETE: api/Contact/5
        public void Delete(Guid id)
        {
        }
    }
}
