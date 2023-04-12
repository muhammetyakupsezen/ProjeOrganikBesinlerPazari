using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeniData;

namespace Business
{
    public class KullaniciIslemleri : BaseKullaniciIslemleri
    {
        static int ExpireMinute = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["TokenExpireMinute"].ToString());
        public TResult GetToken(string KullaniciAdi, string Sifre, string SecretKey)
        {
            TResult result = new TResult();
            result.StatusCode = -1001;
            VwKisiKullaniciIletisim KisiKullanici;
            string Mesaj;
            string Token = "";
            bool Success = base.DoLogin(KullaniciAdi, Sifre, out KisiKullanici, out Mesaj);

            if (Success)
            {
                if (KisiKullanici != null)
                    Token = DoCreateToken(KisiKullanici, SecretKey, ExpireMinute);


                result.Success = Success;
                result.Message = "Token Alındı";
                result.StatusCode = 200;
                result.Data.Add(Token);
                result.Data.Add(KisiKullanici);


            }


            return result;
        }



        private string DoCreateToken(VwKisiKullaniciIletisim KisiKullanici, string SecretKey, int ExpireMinute)
        {
            string result = KisiKullanici.KullaniciId.ToString() + "|" +
                            KisiKullanici.KisiId.ToString() + "|" +
                            KisiKullanici.Tc.ToString() + "|" +
                            DateTime.Now.AddMinutes(ExpireMinute) + "|" +
                            KisiKullanici.Guid.Value;

            result = result.Replace(" ", "+").Replace("-", "_");
            result = Security.TSecurity.Encrypt(result, SecretKey);

            return result;


        }


        public TResult Register(TKullaniciKisiAdresRol kullaniciKisiAdresRol)
        {
            return base.DoRegister(kullaniciKisiAdresRol);

        }



        public TResult GetPersonDetail(string Token, string SecretKey, Guid KullaniciGuid)
        {
            TResult result = new TResult();
            result.StatusCode = -1001;

            TToken OpenToken;
            result = Security.TSecurity.ValidToken(Token, SecretKey, out OpenToken);

            if (result.Success)
            {
                string Mesaj;
                VwKisiKullaniciIletisim KisiKullanici;

                bool Basarili = base.DoGetPersonDetail(KullaniciGuid, out KisiKullanici, out Mesaj);
                result.Message = Mesaj;

                if (Basarili)
                {
                    if (KisiKullanici != null)
                    {
                        result.Success = true;
                        result.StatusCode = 200;
                        result.Data.Add(KisiKullanici);
                    }
                }


            }



            return result;
        }




        public TResult GetPersonDetail(string Token, string SecretKey)
        {
            TResult result = new TResult();
            result.StatusCode = -1001;

            TToken OpenToken;
            result = Security.TSecurity.ValidToken(Token, SecretKey, out OpenToken);

            if (result.Success)
            {
                Guid KullaniciGuid= OpenToken.Guid;
                VwKisiKullaniciIletisim KisiKullanici;
                string Mesaj = "";

                bool Basarili = base.DoGetPersonDetail(KullaniciGuid, out KisiKullanici, out Mesaj);
                result.Message = Mesaj;

                if (Basarili)
                {
                    if (KisiKullanici != null)
                    {
                        result.Success = true;
                        result.StatusCode = 200;
                        result.Data.Add(KisiKullanici);
                    }
                }

            }

           
            return result;
        }


       


    }


}
