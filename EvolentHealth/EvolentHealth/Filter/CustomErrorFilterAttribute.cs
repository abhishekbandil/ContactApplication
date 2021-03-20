using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvolentHealth.Filter
{
    public class CustomErrorFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //Added Logger here.
            base.OnException(filterContext);
        }
    }
}