using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Models
{
    public class KullaniciKisiAdresRol
    {
        //public KullaniciKisiAdresRol(TblKisi tblKisi, TblKullanici tblKullanici, TblAdres tblAdres, TblKullaniciRol tblKullaniciRol)
        //{
        //    TblKisi = tblKisi;
        //    TblKullanici = tblKullanici;
        //    TblAdres = tblAdres;
        //    TblKullaniciRol = tblKullaniciRol;
        //}

        public TblKisi TblKisi { get; set; }
        public TblKullanici TblKullanici { get; set; }

      //  public TblKullaniciRol TblKullaniciRol { get; set; }
        public TblAdres TblAdres { get; set; }
    }
}