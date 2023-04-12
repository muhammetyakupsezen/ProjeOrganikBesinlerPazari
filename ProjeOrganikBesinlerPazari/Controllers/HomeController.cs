using Business;
using ProjeOrganikBesinlerPazari.Models;
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
        DbOrganikUrunEntities db = new DbOrganikUrunEntities();
        public ActionResult Index()
        {


            return View(db.TblUrun.ToList());
        }

        [HttpGet]
        public ActionResult DropdownUrunAra()
        {
            List<SelectListItem> degerler = new List<SelectListItem>();
            var urunler = (from d in db.TblUrun select d).ToList();
            if (urunler != null)
            {
                foreach (var item in urunler)
                {
                    degerler.Add(new SelectListItem
                    {
                        Text = item.UrunAdi,
                        Value = item.UrunId.ToString(),
                    });
                }

            }
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpGet]
        public ActionResult GetImg(int? Id)
        {
            if (Id != null)
            {
                var Urun = (from d in db.TblUrun where d.UrunId == Id select d).FirstOrDefault();
                return View(Urun);

            }

            return View(db.TblUrun.ToList());
        }
        //public ActionResult Details(int UrunNo)
        //{


        //    if (UrunNo != null) 
        //    {
        //        return View(db.TblUrun.Where(r => r.UrunNo == UrunNo).FirstOrDefault());
        //    }

        //    return View(db.TblUrun.ToList());
        //}
        public ActionResult Details(int? UrunId)
        {


            UrunIslemleri urunIslemleri = new UrunIslemleri();


            //   ViewBag.UrunDetay = urunIslemleri.UrunGetir(UrunId);

            if (UrunId != null)
            {
                return View(db.TblUrun.Where(r => r.UrunId == UrunId).SingleOrDefault());
            }
            return View(db.TblUrun.ToList());

        }

        public ActionResult List(int? KategoriId)
        {
            if (KategoriId != null)
            {
                return View(db.TblUrun.Where(r => r.KategoriId == KategoriId).ToList());
            }

            return View(db.TblUrun.ToList());
        }
        public ActionResult KategorikUrunler(int? KategoriId)
        {
            if (KategoriId != null)
            {
                return View(db.TblUrun.Where(r => r.KategoriId == KategoriId).ToList());
            }

            return View(db.TblUrun.ToList());
        }

        public PartialViewResult GetKategorikUrunler()
        {


            return PartialView(db.TblKategori.ToList());
        }
        public PartialViewResult GetCategories()
        {


            return PartialView(db.TblKategori.ToList());
        }


        [HttpPost]
        public ActionResult Login(TblKullanici tblKullanici)
        {
            ////var t = Session["Token"];
            ////t = Session["Login"];
            ////t = Session["KisiId"];
            ////t = Session["KisiAdi"];

         


                string KullaniciAdi = "";
                string Sifre = "";

            KullaniciAdi = Request.Form["KullaniciAdi"].ToString();
            Sifre = Request.Form["Sifre"].ToString();
              

                if (KullaniciAdi == null)
                {
                    ViewBag.Message = "Kullanıcı adı veya şifre boş bırakılamaz";
                }
                else if (Sifre == null)
                {
                    ViewBag.Message = "Kullanıcı adı veya şifre boş bırakılamaz";
                }
                else
                {


                KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

                    bool basarili = kategoriIslemleri.UserLogin(tblKullanici);

                    if (!basarili)
                    {
                        ViewBag.Message = "Giriş başarısız";
                    }
                    else
                {
                    HttpCookie httpCookie = new HttpCookie("ORG");
                  
                    httpCookie.Expires = DateTime.Now.AddMinutes(20);
                    Response.Cookies.Add(httpCookie);

                   
                    Session["Login"] = true;
                    Session["KisiId"] = tblKullanici.KisiId;
                    Session["KisiAdi"] = tblKullanici.KullaniciAdi;
                    //  Session["Kisi"] = KisiKullanici;

                    ViewBag.KullaniciAdi = Session["KisiAdi"].ToString();
                   
                    Response.Redirect("~/Cart", true);
                    }
                }



           


            return View();
        }

        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View();

        //}


      
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult GelenMesaj(TblKullanici tblKullanici)
        {
            ////var t = Session["Token"];
            ////t = Session["Login"];
            ////t = Session["KisiId"];
            ////t = Session["KisiAdi"];




            string KullaniciAdi = "";
            string Sifre = "";

            KullaniciAdi = Request.Form["KullaniciAdi"].ToString();
            Sifre = Request.Form["Sifre"].ToString();


            if (KullaniciAdi == null)
            {
                ViewBag.Message = "Kullanıcı adı veya şifre boş bırakılamaz";
            }
            else if (Sifre == null)
            {
                ViewBag.Message = "Kullanıcı adı veya şifre boş bırakılamaz";
            }
            else
            {


                KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

                bool success = kategoriIslemleri.mesajiKaydet(tblKullanici);

                if (!success)
                {
                    ViewBag.Message = "Giriş başarısız";
                    Response.Redirect("~/Home/Login", true);
                }
                else
                {
                 


                    if (success)
                    {
                        ViewBag.Message = "Mesajınız gönderildi";
                        Response.Redirect("~/Home", true);

                    }
                    else
                    {
                        ViewBag.Message = "Mesajınız gönderilemedi";
                        Response.Redirect("~/Home/Login", true);
                    }
                   

                    //HttpCookie httpCookie = new HttpCookie("ORG");

                    //httpCookie.Expires = DateTime.Now.AddMinutes(20);
                    //Response.Cookies.Add(httpCookie);


                    //Session["Login"] = true;
                    //Session["KisiId"] = tblKullanici.KisiId;
                    //Session["KisiAdi"] = tblKullanici.KullaniciAdi;
                    ////  Session["Kisi"] = KisiKullanici;

                    //ViewBag.KullaniciAdi = Session["KisiAdi"].ToString();

                    //Response.Redirect("~/Cart", true);
                }
            }






            return View();
        }





        public ActionResult Register()
        {
            return View();
        }
        public ActionResult SepetDetay()
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
            //var Kullanici=  db.TblKullanici.Where(i => i.KullaniciAdi = KullaniciAdi).FirstOrDefault();

            //  if (Kullanici != null)
            //  {
            //      Kullanici.Mesaj = Mesaj;
            //      db.SaveChanges();
            //  }
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

        //[HttpPost]
        //public JsonResult CbxUrunListele()
        //{
        //    // TResult result = new TResult();
        //    UrunIslemleri urunIslemleri = new UrunIslemleri();

        //    List<TblUrun> CbxUrunListesi = new List<TblUrun>();
        //    CbxUrunListesi = urunIslemleri.UrunGetir();






        //    return Json(CbxUrunListesi, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public JsonResult AdinaGoreUrunListele(string UrunAdi)
        {
            // TResult result = new TResult();
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            TblUrun RUrun = new TblUrun();
            RUrun = urunIslemleri.AdinaGoreUrunGetir(UrunAdi);


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult UrunListele()
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




        [HttpGet]
        public ActionResult UrunBilgileriGetir(int Id)
        {
            // TResult result = new TResult();
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            TblUrun RUrun = new TblUrun();
            RUrun = urunIslemleri.UrunBilgileriGetir(Id);


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ElmaBilgileriGetir(int Id)
        {
            // TResult result = new TResult();
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            TblUrun RUrun = new TblUrun();
            RUrun = urunIslemleri.ElmaBilgileriGetir(Id);


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ErikBilgileriGetir(int Id)
        {
            // TResult result = new TResult();
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            TblUrun RUrun = new TblUrun();
            RUrun = urunIslemleri.ErikBilgileriGetir(Id);


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }




        [HttpGet]
        public ActionResult AhududuBilgileriGetir(int Id)
        {
            // TResult result = new TResult();
            UrunIslemleri urunIslemleri = new UrunIslemleri();

            TblUrun RUrun = new TblUrun();
            RUrun = urunIslemleri.AhududuBilgileriGetir(Id);


            ViewBag.UrunListesi = RUrun;



            return Json(RUrun, JsonRequestBehavior.AllowGet);
        }




    }
}