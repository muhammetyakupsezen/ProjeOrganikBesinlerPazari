using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public JsonResult UrunListele(int Id)
        {
            // TResult result = new TResult();
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            TblUrun RUrun = new TblUrun();
            RUrun = urunIslemleri.UrunGetir(Id);


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult UrunListele()
        {
            // TResult result = new TResult(); 
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            List<TblUrun> RUrun = new List<TblUrun>();
            RUrun = urunIslemleri.UrunGetir();


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }



        //[HttpPost]
        //public JsonResult UrunGet(string UrunAd)
        //{
        //    // TResult result = new TResult();
        //    UrunIslemleri urunIslemleri = new UrunIslemleri();

        //    List<TblUrun> UrunListesi = new List<TblUrun>();
        //  //  var urun = urunIslemleri.UrunGet(UrunAd);


        //    ViewBag.UrunListesi = UrunListesi;



        //    return Json(urun, JsonRequestBehavior.AllowGet);
        //}




    }
}