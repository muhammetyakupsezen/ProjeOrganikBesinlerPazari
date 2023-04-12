using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;
using YeniData;
using System.Threading;

namespace ProjeOrganikBesinlerPazari.Models
{
    public class TRestClient
    {
        private RestClient client;

        public TRestClient()
        {
            client = new RestClient();

        }


        public string GetToken(string KullaniciAdi, string Sifre, out VwKisiKullaniciIletisim KisiKullanici)
        {
            string result = "";
            KisiKullanici = null;

            string SecretKey = HttpContext.Current.Application["SecretKey"].ToString();

            TApiUser User = new TApiUser();
            User.KullaniciAdi = KullaniciAdi;
            User.Sifre = Sifre;

            client = new RestClient(TSiteSettings.ApiUrl + "Token");

            var Request = new RestRequest();
            Request.AddJsonBody<TApiUser>(User);
            Request.AddHeader("SecretKey", SecretKey);

            var response = client.Post(Request);

            TResult ResultData = JsonConvert.DeserializeObject<TResult>(response.Content);

            if (ResultData.Success)
            {
                result = ResultData.Data[0].ToString();
                KisiKullanici = JsonConvert.DeserializeObject<VwKisiKullaniciIletisim>(ResultData.Data[1].ToString());
            }


            return result;

        }



        public TResult Register(KullaniciKisiAdresRol kullaniciKisiAdresRol)
        {
            TResult result = new TResult();
            string r = "";

            try
            {

                RestClient restClient = new RestClient(TSiteSettings.ApiUrl + "User");
                RestRequest Request = new RestRequest();
                Request.AddJsonBody(kullaniciKisiAdresRol);


                RestResponse restResponse = new RestResponse();

                restResponse = restClient.Post(Request);

                var t = restResponse.Content;

                TResult resultData = JsonConvert.DeserializeObject<TResult>(restResponse.Content);
                result = resultData;
            }
            catch (Exception e)
            {

                throw;
            }
            // This exception was originally thrown at this call stack:
            // [External Code] ProjeOrganikBesinlerPazari.Models.TRestClient.Register(ProjeOrganikBesinlerPazari.Models.KullaniciKisiAdresRol)
            //if (resultData.Success)
            //{
            //    r = resultData.Data[0].ToString();
            // var   k =  JsonConvert.DeserializeObject<TResult>(resultData.Data[1].ToString());
            //}                                                          // in TRestClient.cs ProjeOrganikBesinlerPazari.Controllers.ApiController.Register(string, string, System.DateTime, long,
            //                                                           // string, string, string, string)
            // in ApiController.cs [External Code]
            // System.Net.Http.HttpRequestException: 'Request failed with status code InternalServerError'
            return result;
        }




        public TResult GetUserDetail(string SecretKey, string Token)
        {
            TResult result = new TResult();

            RestClient restClient = new RestClient(TSiteSettings.ApiUrl + "/User/");
            var request = new RestRequest();
            request.AddHeader("SecretKey", SecretKey);
            request.AddHeader("Token", Token);

           var response = restClient.Get(request);

            result = JsonConvert.DeserializeObject<TResult>(response.Content);

            return result;
        }






    }
}