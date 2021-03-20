using EvolentHealth.Filter;
using System.Web;
using System.Web.Mvc;

namespace EvolentHealth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomErrorFilterAttribute());
        }
    }
}
