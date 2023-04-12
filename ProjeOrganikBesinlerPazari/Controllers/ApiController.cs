using Newtonsoft.Json;
using ProjeOrganikBesinlerPazari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api


        [HttpPost]
        public ActionResult Login(string KullaniciAdi, string Sifre)
        {
            TRestClient restClient = new TRestClient();
            VwKisiKullaniciIletisim KisiKullanici;

            var ResultData = restClient.GetToken(KullaniciAdi, Sifre, out KisiKullanici);

            if (ResultData != null)
            {
                if (ResultData != "")
                {

                    if (KisiKullanici.Admin !=true)
                    {
                        HttpCookie httpCookie = new HttpCookie("ORG");
                        httpCookie.Values["Token"] = ResultData;
                        httpCookie.Expires = DateTime.Now.AddMinutes(20);
                        Response.Cookies.Add(httpCookie);

                        Session["Token"] = ResultData;
                        Session["Login"] = true;
                        Session["KisiId"] = KisiKullanici.KisiId;
                        Session["KisiAdi"] = KisiKullanici.Ad;
                        //  Session["Kisi"] = KisiKullanici;

                        ViewBag.KullaniciAdi = Session["KisiAdi"].ToString();
                        Response.Redirect("~/Cart", true);

                    }
                    else
                    {
                        HttpCookie httpCookie = new HttpCookie("ORG");
                        httpCookie.Values["Token"] = ResultData;
                        httpCookie.Expires = DateTime.Now.AddMinutes(20);
                        Response.Cookies.Add(httpCookie);

                        Session["Token"] = ResultData;
                        Session["Login"] = true;
                        Session["KisiId"] = KisiKullanici.KisiId;
                        Session["KisiAdi"] = KisiKullanici.KullaniciAdi;
                        //  Session["Kisi"] = KisiKullanici;

                        ViewBag.KullaniciAdi = Session["KisiAdi"].ToString();
                        Response.Redirect("~/Product/Index",true);
                    }




                }
            }



            return Json(ResultData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LogOut()
        {
            HttpCookie nameCookie = Request.Cookies["ORG"];
               string CookieToken = nameCookie != null ? nameCookie.Value.Split('=')[1] : "undefined";
              // string SessionToken = HttpContext.Application["Token"].ToString();

              
            nameCookie.Values["Token"] = "";
            //

            Session["Token"] = "";
            Session["Login"] = false;
            Session["KisiId"] = "";
            Session["KisiAdi"] = "";

            return RedirectToAction("Index","Home");

        }


        [HttpPost]
        public ActionResult Register(string Ad, string Soyad, DateTime DogumTarihi, Int64 Tc, string KullaniciAdi, string Sifre, string Adres, string AdresBasligi)
        {
            TblKisi Kisi = new TblKisi();
            TblKullanici Kullanici = new TblKullanici();
            TblAdres adres = new TblAdres();
            TblKullaniciRol KullaniciRol = new TblKullaniciRol();

            KullaniciKisiAdresRol kullaniciKisiAdresRol = new KullaniciKisiAdresRol();
            kullaniciKisiAdresRol.TblKisi = Kisi;
            kullaniciKisiAdresRol.TblKullanici = Kullanici;

            kullaniciKisiAdresRol.TblAdres = adres;
            //  kullaniciKisiAdresRol.TblKullaniciRol = null;
            /*new TblKisi(), new TblKullanici(), new TblAdres(), new TblKullaniciRol()*/


            kullaniciKisiAdresRol.TblKisi.Ad = Ad;
            kullaniciKisiAdresRol.TblKisi.Soyad = Soyad;
            kullaniciKisiAdresRol.TblKisi.DogumTarihi = DogumTarihi;
            kullaniciKisiAdresRol.TblKisi.Tc = Tc;
            kullaniciKisiAdresRol.TblKullanici.KullaniciAdi = KullaniciAdi;
            kullaniciKisiAdresRol.TblKullanici.Sifre = Sifre;

            kullaniciKisiAdresRol.TblAdres.Adres = Adres;
            kullaniciKisiAdresRol.TblAdres.AdresBasligi = AdresBasligi;



            TRestClient restClient = new TRestClient();
            TResult result = restClient.Register(kullaniciKisiAdresRol);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {





            return View();
        }


        // GET: Api/Details/5
        //[HttpGet]
        //public ActionResult GetUserDetails()
        //{
        //    HttpCookie nameCookie = Request.Cookies["ORG"];
        //    string CookieToken = nameCookie != null ? nameCookie.Value.Split('=')[1] : "undefined";
        //    string SessionToken = HttpContext.Application["Token"].ToString();

        //    TResult result = new TResult();
        //    VwKisiKullaniciIletisim KisiKullanici = new VwKisiKullaniciIletisim();

        //    if (SessionToken.IndexOf(CookieToken) > -1) 
        //    {
        //        TRestClient restClient = new TRestClient();
        //        result = restClient.GetUserDetail(HttpContext.Application["SecretKey"].ToString(), SessionToken);
        //        KisiKullanici = JsonConvert.DeserializeObject<VwKisiKullaniciIletisim>(result.Data[0].ToString());
        //        KisiKullanici.Sifre = "***";
        //    }
        //    //var JsonHali = JsonConvert.SerializeObject(KisiKullanici, (Formatting)JsonRequestBehavior.AllowGet);

        //    return Json(KisiKullanici, JsonRequestBehavior.AllowGet);
        //}

        // GET: Api/Create


        public ActionResult Create()
        {
            return View();
        }

        // POST: Api/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Api/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Api/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Api/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Api/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
