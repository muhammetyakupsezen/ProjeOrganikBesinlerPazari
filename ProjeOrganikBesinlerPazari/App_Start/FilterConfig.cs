using System.Web;
using System.Web.Mvc;

namespace ProjeOrganikBesinlerPazari
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
