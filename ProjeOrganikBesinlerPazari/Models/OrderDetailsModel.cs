using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOrganikBesinlerPazari.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<double> OrderTotal { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string SiparisDurumu { get; set; }
        public int Id { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string img { get; set; }





    }
}