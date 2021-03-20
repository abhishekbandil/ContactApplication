using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EvolentHealth.Model;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.BAL.ApiCall
{
    public interface IWebApiCall
    {
        HttpResponseMessage Get();

        HttpResponseMessage Post(Model.Contact content);

        HttpResponseMessage Get(int id);

        HttpResponseMessage Put(Model.Contact content);

        HttpResponseMessage Delete(int id);

    }
}
