using ProjeOrganikBesinlerPazari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class OrderController : Controller
    {
        DbOrganikUrunEntities db = new DbOrganikUrunEntities();

        // GET: Order
        public ActionResult Index()
        {
            var AdminSiparisler = db.VwSiparisDetayUrun.Select(i => new AdminOrderModel()
            {
                OrderId = i.OrderId,
                OrderNumber = i.OrderNumber,
                OrderDate   = (DateTime)i.OrderDate,
                SiparisDurumu = i.SiparisDurumu,
                OrderTotal = (double)i.OrderTotal,
                
                
             
                

            }).OrderByDescending(i=>i.OrderDate).ToList();


            return View(AdminSiparisler);
        }


        public ActionResult SiparislerinDetaylari(int OrderId)
        {
            var DonenEntity = db.VwSiparisDetayUrun.Where(i => i.OrderId == OrderId).Select(i => new OrderDetailsModel()
            {
                OrderId = i.OrderId,
                OrderNumber = i.OrderNumber,
               
                OrderTotal = i.OrderTotal,
                OrderDate = i.OrderDate,
                SiparisDurumu = i.SiparisDurumu,
                AdresBasligi = i.AdresBasligi,
                Adres = i.Adres,
                UlkeAdi = i.UlkeAdi,
                IlAdi = i.IlAdi,
                IlceAdi = i.IlceAdi,
                
                UrunId = i.UrunId,
                UrunAdi = i.UrunAdi,
                img = i.img,
                Quantity = i.Quantity,
                Price = i.Price,
                KullaniciAdi = i.KullaniciAdi


            }).FirstOrDefault();



            return View(DonenEntity);

        }

        public ActionResult SiparisDurumunuDegistir(int? OrderId, string SiparisDurumu)
        {
            //db.TblOrder.Where(i => i.OrderId == OrderId).Select(i => new TblOrder()

            var Siparis = (from d in db.TblOrder where d.OrderId == OrderId select d).FirstOrDefault();

            if (Siparis != null)
            {
                Siparis.SiparisDurumu = SiparisDurumu;
                db.SaveChanges();
                //if (Siparis.SiparisDurumu == "siparis onayi bekliyor")
                //{
                //    Siparis.SiparisDurumu = "onaylandi";
                //}
                //else if (Siparis.SiparisDurumu == "onaylandi")
                //{
                //    Siparis.SiparisDurumu = "siparis onayi bekliyor";
                //}
                //else
                //{
                //    Siparis.SiparisDurumu = "siparis onayi bekliyor";
                //}
                //return View(Siparis);
                return RedirectToAction("SiparislerinDetaylari", new { OrderId = OrderId }); ;
            }


            return RedirectToAction("Index");
        }


    }
}