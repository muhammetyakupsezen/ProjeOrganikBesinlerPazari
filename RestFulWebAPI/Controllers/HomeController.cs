using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestFulWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var t = Session["Token"];
            t = Session["Login"];
            t = Session["KisiId"];
            t = Session["KisiAdi"];
            return View();
        }
    }
}
