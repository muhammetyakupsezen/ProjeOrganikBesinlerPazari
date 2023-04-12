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

                Mesaj = ex.Message;
            }

            return result;
        }



        internal TResult DoRegister(TKullaniciKisiAdresRol KullaniciKisiAdresRol)
        {
            TResult result = new TResult();


            bool ExistUser()
            {
                bool Exist = false;

                var Kisi = (from d in db.TblKisi where d.Tc == KullaniciKisiAdresRol.TblKisi.Tc select d).FirstOrDefault();
                if (Kisi != null)
                {
                    Exist = true;
                }

                return Exist;
            }


            try
            {
                TblKisi Kisi = KullaniciKisiAdresRol.TblKisi;
                TblKullanici Kullanici = KullaniciKisiAdresRol.TblKullanici;
               // TblKullaniciRol KullaniciRol = KullaniciKisiAdresRol.TblKullaniciRol;
                TblAdres Adres = KullaniciKisiAdresRol.TblAdres;

                if (!ExistUser())
                {
                    db.TblKisi.Add(Kisi);
                    db.SaveChanges();
                    Kullanici.KisiId = Kisi.KisiId;

                    Kullanici.Sifre = Security.TSecurity.StrToMd5(Kullanici.Sifre);
                    db.TblKullanici.Add(Kullanici);
                    db.SaveChanges();


                    //KullaniciRol.KullaniciId = Kullanici.KullaniciId;
                    //db.TblKullaniciRol.Add(KullaniciRol);
                    //db.SaveChanges();
                    
                    db.TblAdres.Add(Adres);
                    db.SaveChanges();

                    //foreach (var item in Adres)
                    //{
                    //    item.AdresId = (int)Kisi.AdresId;
                    //    db.TblAdres.Add(item);
                    //    db.SaveChanges();
                    //}
                    Kullanici.Sifre = "";


                    

                    result.Data.Add(Kisi);
                    result.Data.Add(Kullanici);                    
                //    result.Data.Add(KullaniciRol);
                    result.Data.Add(Adres);


                    result.Success = true;
                    result.StatusCode = 200;
                    result.Message = "Kayıtlar başarıyla girildi";

                }

            }
            catch (Exception ex)
            {

                result.Success=false;
                result.Message = ex.Message;
                result.StatusCode = -1001;

            }


            return result;
        }



        internal bool DoGetPersonDetail(Guid KullaniciGuid, out VwKisiKullaniciIletisim KisiKullanici , out string Mesaj )
        {
            bool result = false;
            KisiKullanici = null;
            Mesaj = "";

            try
            {
                var KisiKayıt = (from d in db.VwKisiKullaniciIletisim where d.Guid.Value == KullaniciGuid select d).FirstOrDefault();

                if (KisiKayıt == null)
                {
                    Mesaj = "Kullanıcı Bilgileri hatalı";
                }
                else
                {
                    KisiKullanici = KisiKayıt;
                    result = true;
                }

            }
            catch (Exception ex)
            {
                Mesaj = ex.Message;

            }


            return result;

        }



     




    }
}
