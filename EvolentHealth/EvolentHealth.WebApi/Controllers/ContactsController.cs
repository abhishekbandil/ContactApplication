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
    /// <summary>
    /// Web Api Contacts Controller
    /// </summary>
    public class ContactsController : ApiController
    {
        public IContactManager _contactManager;

        public ContactsController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        // GET: api/Contact
        public IHttpActionResult Get()
        {
            try
            {
                var con = _contactManager.GetContactList();

                return Ok(con);
            }
            catch (Exception ex)
            {
                //Added Logger here.
                //Also we can handle exception in Exception Filter

                return InternalServerError();
            }
        }

        // GET: api/Contact/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var con = _contactManager.GetContact(id);

                if (con == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(con);
                }
            }
            catch (Exception ex)
            {
                //Added Logger here.
                //Also we can handle exception in Exception Filter

                return InternalServerError();
            }

        }

        // POST: api/Contact
        public IHttpActionResult Post([FromBody]Contact value)
        {
            try
            {
                _contactManager.AddContact(value);
                return Ok();
            }
            catch (Exception ex)
            {
                //Added Logger here.
                //Also we can handle exception in Exception Filter
                return InternalServerError();
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put([FromBody]Contact value)
        {
            try
            {
                var success = _contactManager.EditContact(value);
                if (success)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                //Added Logger here.
                //Also we can handle exception in Exception Filter
                return InternalServerError();
            }
        }

        // DELETE: api/Contact/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var success = _contactManager.DeleteContact(id);
                if (success)
                    return Ok();
                else
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Server Error"));
            }
            catch (Exception ex)
            {
                //Added Logger here.
                //Also we can handle exception in Exception Filter
                return InternalServerError();
            }
        }
    }
}
