using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeniData;

namespace Business
{
    public class BaseKullaniciIslemleri
    {
        private DbOrganikUrunEntities db;
        public BaseKullaniciIslemleri()
        {
            db = new DbOrganikUrunEntities();
        }


        internal bool DoLogin(string KullaniciAdi, string Sifre, out VwKisiKullaniciIletisim KisiKullanici, out string Mesaj)
        {
            bool result = false;
            Mesaj = "";
            KisiKullanici = null;

            try
            {
                var KisiKaydi = (from d in db.VwKisiKullaniciIletisim where d.KullaniciAdi == KullaniciAdi && d.Sifre == Sifre select d).FirstOrDefault();

                if (KisiKaydi == null)
                {
                    Mesaj = "Kullanıcı bilgileri hatalı ";
                }
                else
                {
                    if (KisiKaydi != null)
                    {
                        if (Security.TSecurity.StrToMd5(KisiKaydi.Sifre) != Security.TSecurity.StrToMd5(Sifre))
                        {
                            Mesaj = "Kullanıcı bilgileri hatalı ";
                            result = false;
                        }
                        
                            KisiKullanici = KisiKaydi;
                           result = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {

              Mesaj =ex.Message;
            }

            return result;
        }

















    }
}
