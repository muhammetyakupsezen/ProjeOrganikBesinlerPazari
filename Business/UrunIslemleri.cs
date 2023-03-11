
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

        public TblUrun UrunGetir(int ID)
        {
            
            TblUrun Urun = new TblUrun();

                  var BulunanUrun = (from d in db.TblUrun where d.UrunId == ID  select d).FirstOrDefault();

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




    }
}
