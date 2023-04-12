using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeniData;

namespace Business
{
    public class SepetIslemleri
    {
        private DbOrganikUrunEntities db;

        public SepetIslemleri()
        {
            db = new DbOrganikUrunEntities();
        }



        public TblSepet SepetGetir(int SepetId, out List<VwSepetDetay> SepetDetay)
        {

            SepetDetay = null;

            TblSepet result = (from s in db.TblSepet where s.SepetId == SepetId select s).SingleOrDefault();

            if (result != null)
            {

                SepetDetay = (from sepetdetay in db.VwSepetDetay where sepetdetay.SepetId == result.SepetId select sepetdetay).ToList();

            }

            return result;

        }




        public static List<TblSepetDetay> SepetListesi = new List<TblSepetDetay>(); 


        public static void SepeteEkle(TblSepetDetay SepetDetay, out bool Eklendi)
        {
            Eklendi = false;

            int Index = SepetListesi.FindIndex(r=>r.UrunId == SepetDetay.UrunId);

            if (Index > -1 )
            {
                SepetListesi[Index].Adet += SepetDetay.Adet;
                Eklendi = true;
            }
            else
            {
                Eklendi = true;
                SepetListesi.Add(SepetDetay);
            }

        }


        public static void SepetiTemizle()
        {
            SepetListesi.Clear();

        }

        public static double SepetToplamı(out int UrunSayisi)
        {
            UrunSayisi = SepetListesi.Count;
            double result = SepetListesi.Sum(r => r.BirimFiyat);
            return result;


        }



    }
}
