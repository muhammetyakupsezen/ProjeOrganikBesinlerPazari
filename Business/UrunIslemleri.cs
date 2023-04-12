
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeniData;

namespace Business
{
    public class UrunIslemleri
    {
        private DbOrganikUrunEntities db;
      //  private DbProjeOrganikBesinlerPazariEntity YedekDb;
        public UrunIslemleri()
        {
            db = new DbOrganikUrunEntities();
        }


        public TblUrun UrunGetir(int UrunId)
        {
            
            TblUrun Urun = new TblUrun();

                  var BulunanUrun = (from d in db.TblUrun where d.UrunId == UrunId  select d).FirstOrDefault();

                if (BulunanUrun != null)
                {
                  Urun = BulunanUrun;


                }

            return Urun;


        }

        public TblUrun AdinaGoreUrunGetir(string UrunAdi)
        {

            TblUrun Urun = new TblUrun();

            var BulunanUrun = (from d in db.TblUrun where d.UrunAdi.Contains( UrunAdi) select d).FirstOrDefault();
    

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        }
         public TblUrun UrunBilgileriGetir(int Id)
        {

            TblUrun Urun = new TblUrun();

            var BulunanUrun = (from d in db.TblUrun where d.UrunId == Id select d).FirstOrDefault();
    

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        } 
        
        public TblUrun ElmaBilgileriGetir(int Id)
        {

            TblUrun Urun = new TblUrun();

            var BulunanUrun = (from d in db.TblUrun where d.UrunId == Id select d).FirstOrDefault();
    

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        }
       
          public TblUrun ErikBilgileriGetir(int Id)
        {

            TblUrun Urun = new TblUrun();

            var BulunanUrun = (from d in db.TblUrun where d.UrunId == Id select d).FirstOrDefault();
    

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        }
        
         public TblUrun AhududuBilgileriGetir(int Id)
        {

            TblUrun Urun = new TblUrun();

            var BulunanUrun = (from d in db.TblUrun where d.UrunId == Id select d).FirstOrDefault();
    

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        }  



        public List< TblUrun> UrunGetir()
        {

            List<TblUrun> Urun = new List<TblUrun>();

            var BulunanUrun = (from d in db.TblUrun orderby d.UrunAdi  select d).ToList();

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        }

        //public TblUrun UrunGet(string UrunAd)
        //{
        //    TblUrun tblUrun = new TblUrun();
        //    var urunum = (from d in db.TblUrun orderby d.UrunAdi == UrunAd select d).FirstOrDefault();
        //    if (urunum != null)
        //    {
        //        tblUrun = urunum;
        //    }
        //    return tblUrun;
        //}


        //verilen kategori ıdye göre aynıkategorideki tüm urunleri getiriyor
        public List<VwKategorikUrunler> KategorikUrunGetir(int KategoriId)
        {

            return (from urun in db.VwKategorikUrunler where urun.KategoriId == KategoriId select urun).ToList();

        }


        /// tümürünleri isme göre getiriyor
        public List<TblUrun> UrunListesi()
        {

            List<TblUrun> Urun = new List<TblUrun>();

            var BulunanUrun = (from d in db.TblUrun orderby d.UrunAdi select d).ToList();

            if (BulunanUrun != null)
            {
                Urun = BulunanUrun;


            }

            return Urun;


        }



        public List<TblUrunKategori> UrunKategorileriListesi()
        {
            return (from UrunKategorisi in db.TblUrunKategori  orderby UrunKategorisi.Id select UrunKategorisi ).ToList();


        }







    }
}
