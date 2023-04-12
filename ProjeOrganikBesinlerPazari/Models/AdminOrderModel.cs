using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOrganikBesinlerPazari.Models
{
    public class AdminOrderModel
    {

        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }


        public string KullaniciAdi { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string SiparisDurumu { get; set; }
        //public int Count { get; set; }



        public virtual List<OrderLine> OrderLines { get; set; }



    }
}