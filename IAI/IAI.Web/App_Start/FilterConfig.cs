using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IAI.Web.Tools;

namespace IAI.Web
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection collection)
        {
            collection.Add(new HandleLogicErrorAttribute());
        }
    }
}