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
        DbOrganikUrunEntities db = new DbOrganikUrunEntities();

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



        //public ActionResult Update(TblUrun urun)
        //{

        //    TblUrun BulunanUrun = (from d in db.TblUrun where d.UrunId == urun.UrunId select d).SingleOrDefault();

        //    if (BulunanUrun != null)
        //    {
        //        BulunanUrun.UrunAdi = urun.UrunAdi;
        //        BulunanUrun.UrunNo = urun.UrunNo;
        //        BulunanUrun.Aciklama = urun.Aciklama;
        //        BulunanUrun.UrunFiyati = urun.UrunFiyati;
        //        BulunanUrun.IsApproved = urun.IsApproved;
        //        BulunanUrun.img = urun.img;
        //        BulunanUrun.IsAtDiscount = urun.IsAtDiscount;
        //        BulunanUrun.IsExist = urun.IsExist;
        //        BulunanUrun.KategoriId = urun.KategoriId;
        //        BulunanUrun.Yol = urun.Yol;
        //        BulunanUrun.StokAdedi = urun.StokAdedi;
        //        BulunanUrun.UrunKategorisi = urun.UrunKategorisi;
        //        db.SaveChanges();
        //    }


        //    return View(BulunanUrun);
        //}



    }
}