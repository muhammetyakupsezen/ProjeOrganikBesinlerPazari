using ProjeOrganikBesinlerPazari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class CartController : Controller
    {
        DbOrganikUrunEntities db = new DbOrganikUrunEntities();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.TblUrun.Where(i => i.UrunId == id).FirstOrDefault();

            if (product != null)
            {
                GetCart().AddProduct(product,1);
            }

            return RedirectToAction("Index");
        }
         public ActionResult RemoveFromCart(int id)
        {
            var product = db.TblUrun.Where(i => i.UrunId == id).FirstOrDefault();

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {

            var cart =(Cart) Session["Cart"];

            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }


        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }


        public ActionResult CheckOut()
        {

            return View(new ShippingDetails());
        }

        [HttpPost]
         public ActionResult CheckOut(ShippingDetails SiparisDetay)
        {
            var cart = GetCart();

            if (cart.CartLines.Count ==0)
            {
                ModelState.AddModelError("SepetteUrunYok", "Sepette Ürün Bulunmamaktadır");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, SiparisDetay);

                cart.Clear();
                return View("SiparisTamamlandi");
            }
            else
            {
                return View(SiparisDetay);

            }



           
        }

        private void SaveOrder(Cart cart, ShippingDetails siparisDetay)
        {
            TblOrder tblOrder = new TblOrder();

            tblOrder.OrderNumber = "A"+(new Random()).Next(11111, 99999).ToString();
            tblOrder.OrderTotal = cart.TotalPrice();
            tblOrder.OrderDate = DateTime.Now;
           

            tblOrder.KullaniciAdi = siparisDetay.KullaniciAdi;
         
            tblOrder.KullaniciAdi = (Session["KisiAdi"]).ToString();

            tblOrder.AdresBasligi = siparisDetay.AdresBasligi;
            tblOrder.Adres = siparisDetay.Adres;
            tblOrder.UlkeAdi = siparisDetay.UlkeAdi;
            tblOrder.IlAdi = siparisDetay.IlAdi;
            tblOrder.IlceAdi = siparisDetay.IlceAdi;

            tblOrder.TblOrderLines = new List<TblOrderLines>();


            foreach (var pr in cart.CartLines)
            {
                var orderLine = new TblOrderLines();
                orderLine.Quantity = pr.Quantity;

                orderLine.Price = pr.Quantity * pr.Urun.UrunFiyati;
                orderLine.UrunId = pr.Urun.UrunId;

                tblOrder.TblOrderLines.Add(orderLine);
            }

            db.TblOrder.Add(tblOrder);
            db.SaveChanges();

        }




    }
}