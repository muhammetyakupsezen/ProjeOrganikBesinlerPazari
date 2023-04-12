using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjeOrganikBesinlerPazari
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "SepetDetay",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "SepetDetay", id = UrlParameter.Optional }
          );

            // routes.MapRoute(
            //    name: "IndexPanel",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Urun", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
