using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeniData;

namespace Business
{
    public class KategoriIslemleri
    {

        private DbOrganikUrunEntities db;


        public KategoriIslemleri()
        {
            db = new DbOrganikUrunEntities();

        }


        public List <TblKategori> Kategoriler()
        {
            return (from kategori in db.TblKategori orderby kategori.KategoriAdi select kategori).ToList();


        }




        public bool BaseUserLogin(TblKullanici tblKullanici)
        {
            bool basarili = false;

            var DonenKullanici = (from d in db.TblKullanici where d.KullaniciAdi == tblKullanici.KullaniciAdi && d.Sifre == tblKullanici.Sifre select d).SingleOrDefault();

            if (DonenKullanici != null)
            {


                basarili = true;

            }


            return basarili;

        }


        public bool UserLogin(YeniData.TblKullanici tblKullanici)
        {
            bool result = false;

            result = BaseUserLogin(tblKullanici);



            return result;
        }


        public bool mesajiKaydet(TblKullanici tblKullanici)
        {
            bool result = false;


            if (tblKullanici != null)
            {
                var Kullanici = (from d in db.TblKullanici where d.KullaniciAdi == tblKullanici.KullaniciAdi && d.Sifre == tblKullanici.Sifre select d).FirstOrDefault();

                if (Kullanici != null)
                {
                    
                    Kullanici.Mesaj = tblKullanici.Mesaj;
                    db.SaveChanges();
                    result = true;


                }

            }

            return result;
        }




    }
}
