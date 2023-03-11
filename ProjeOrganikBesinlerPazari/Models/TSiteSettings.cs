using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOrganikBesinlerPazari.Models
{
    public static class TSiteSettings
    {

        public static string ApiUrl = System.Configuration.ConfigurationSettings.AppSettings["ApiUrl"].ToString();

    }
}