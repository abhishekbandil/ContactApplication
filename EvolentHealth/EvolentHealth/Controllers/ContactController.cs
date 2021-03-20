using EvolentHealth.BAL.ApiCall;
using EvolentHealth.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EvolentHealth.Controllers
{
    /// <summary>
    /// Contact Controller
    /// </summary>
    public class ContactController : Controller
    {
        IWebApiCall _webApiCall;

        public ContactController(IWebApiCall webApiCall)
        {
            _webApiCall = webApiCall;
        }

        // GET: Contact
        public ActionResult Index()
        {
            var result = _webApiCall.Get();

            if (result.IsSuccessStatusCode)
            {
                var contacts = result.Content.ReadAsStringAsync().Result;
                var s = new JavaScriptSerializer().Deserialize<List<Contact>>(contacts);
                return View(s);
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact con)
        {
            var response = _webApiCall.Post(con);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditContact(int id)
        {
            var result = _webApiCall.Get(id);

            if (result.IsSuccessStatusCode)
            {
                var contacts = result.Content.ReadAsStringAsync().Result;
                var s = new JavaScriptSerializer().Deserialize<Contact>(contacts);

                return View(s);
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditContact(Contact con)
        {
            var result = _webApiCall.Put(con);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult DeleteContact(int id)
        {
            var result = _webApiCall.Delete(id);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}