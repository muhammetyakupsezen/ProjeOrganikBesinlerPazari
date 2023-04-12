using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeOrganikBesinlerPazari.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="Lütfen İsim Soyisim Giriniz")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Baslığı Giriniz")]
        public string  AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Giriniz")]
        public string  Adres { get; set; }
        public string  UlkeAdi { get; set; }
        public string  IlAdi { get; set; }
        public string  IlceAdi { get; set; }
        


    }
}