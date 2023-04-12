using ProjeOrganikBesinlerPazari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class AccountController : Controller
    {
        DbOrganikUrunEntities db = new DbOrganikUrunEntities();
        // GET: Account
        public ActionResult Index()
        {

            string SessionKullaniciAdi = (Session["KisiAdi"].ToString());
            //(from d in db.TblOrder where d.KullaniciAdi == ((TblKullanici)Session["KisiAdi"]).KullaniciAdi select d).ToString(); 
            var orders = db.VwSiparisDetayUrun.Where(i => i.KullaniciAdi == SessionKullaniciAdi).Select(i => new Order()
            {
                OrderId = i.OrderId,
                OrderNumber = i.OrderNumber,
                OrderDate = (DateTime)i.OrderDate,
                OrderTotal =(double) i.OrderTotal
            }).OrderByDescending(i=>i.OrderDate).ToList();


            return View(orders);
        }



        public ActionResult SiparisDetay(int OrderId)
        {
            var DonenEntity = db.VwSiparisDetayUrun.Where(i => i.OrderId == OrderId).Select(i => new OrderDetailsModel()
            {
                OrderId =i.OrderId,
                OrderNumber =i.OrderNumber,
                OrderTotal = i.OrderTotal,
                OrderDate =i.OrderDate,
                SiparisDurumu =i.SiparisDurumu,
                AdresBasligi =i.AdresBasligi, 
                Adres =i.Adres,
                UlkeAdi = i.UlkeAdi,
                IlAdi =i.IlAdi,               
                IlceAdi =i.IlceAdi,      
                
                UrunId= i.UrunId,
                UrunAdi = i.UrunAdi,
                img =i.img,
                Quantity =i.Quantity,
                Price =i.Price,
                KullaniciAdi =i.KullaniciAdi


            }).FirstOrDefault();



            return View(DonenEntity);
        }


    }
}