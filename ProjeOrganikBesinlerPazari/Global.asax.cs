﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjeOrganikBesinlerPazari
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["SecretKey"] = System.Configuration.ConfigurationSettings.AppSettings["SecretKey"].ToString(); 

        }

        protected void Session_Start()
        {
            Session["Token"] = "";
            Session["Login"] = false;
            Session["KisiId"] = "";
            Session["KisiAdi"] = "";
            Session["Kisi"] = "";




        }


    }
}
