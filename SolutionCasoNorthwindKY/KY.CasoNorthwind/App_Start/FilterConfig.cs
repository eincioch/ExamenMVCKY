using System.Web;
using System.Web.Mvc;

namespace KY.CasoNorthwind
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
