using Business;
using YeniData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class UrunController : Controller
    {
        UrunIslemleri urunIslemleri;
        // GET: Urun
        public UrunController()
        {
            urunIslemleri = new UrunIslemleri();
        }


        //[HttpGet]
        //public ActionResult Index()
        //{
        //     // TResult result = new TResult();
            
            
        //    List<TblUrun> UrunListesi = new List<TblUrun>();
        //    UrunListesi = urunIslemleri.UrunGetir();
          
            
        //   ViewBag.UrunListesi = UrunListesi;   
               
          

        //    return Json(UrunListesi, JsonRequestBehavior.AllowGet);
        //}
    }
}