using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EvolentHealth.BAL.ApiCall.Impl
{
    public class WebApiCall : IWebApiCall
    {
        const string URL = "http://localhost:2108/";

        public HttpResponseMessage Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                //HTTP POST
                var response = client.GetAsync("api/Contacts");

                return response.Result;
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                //HTTP POST
                var response = client.GetAsync("api/Contacts/" + id);

                return response.Result;
            }
        }

        public HttpResponseMessage Post(Model.Contact con)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                var content = new StringContent(new JavaScriptSerializer().Serialize(con), Encoding.UTF8, "application/json");

                //HTTP POST
                var response = client.PostAsync("api/Contacts", content);

                return response.Result;
            }
        }


        public HttpResponseMessage Put(Model.Contact con)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                var content = new StringContent(new JavaScriptSerializer().Serialize(con), Encoding.UTF8, "application/json");

                //HTTP Get
                var response = client.PutAsync("api/Contacts/", content);

                return response.Result;
            }
        }


        public HttpResponseMessage Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                //HTTP Get
                var response = client.DeleteAsync("api/Contacts/" + id);

                return response.Result;
            }
        }

    }
}
