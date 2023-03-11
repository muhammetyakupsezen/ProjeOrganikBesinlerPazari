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
        public TResult GetToken(string KullaniciAdi, string Sifre,  string SecretKey)
        {
            TResult result = new TResult();
            result.StatusCode = -1001;
            VwKisiKullaniciIletisim KisiKullanici;
            string Mesaj;
            string Token = "";
            bool Success = base.DoLogin(KullaniciAdi, Sifre, out KisiKullanici, out Mesaj );

            if (Success)
            {
                if (KisiKullanici != null)
                {
                    Token = DoCreateToken(KisiKullanici,SecretKey, ExpireMinute);
                    result.Success = true;
                    result.Message = "Token Alındı";
                    result.StatusCode = 200;
                    result.Data.Add(Token);
                    result.Data.Add(KisiKullanici);
                }

            }


            return result;
        }



        private string  DoCreateToken(VwKisiKullaniciIletisim KisiKullanici, string SecretKey, int ExpireMinute)
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





    }


}
