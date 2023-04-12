using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Models
{
    //ÖRNEK SINIF KULLANILMIYOR TBLORDER VAR AYRICA KULLANIMDA OLAN
    public class Order
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



        public virtual List<OrderLine> OrderLines { get; set; }

    }
    
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual  Order Order { get; set; }


        public int Quantity { get; set; }
        public double Price { get; set; }


        public int ProductId { get; set; }
        public TblUrun Product { get; set; }








    }
}