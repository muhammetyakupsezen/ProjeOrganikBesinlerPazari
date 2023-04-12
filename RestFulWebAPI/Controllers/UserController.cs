using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YeniData;

namespace RestFulWebAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get(int i)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.StatusCode = HttpStatusCode.Unauthorized;

            IEnumerable<string> TokenValues;
            IEnumerable<string> SecretKeyValues;

           var GetToken = Request.Headers.TryGetValues("Token",out TokenValues);
           var GetSecretKey = Request.Headers.TryGetValues("SecretKey",out SecretKeyValues);

            if (GetToken && GetSecretKey)
            {
                string Token = TokenValues.First();
                string SecretKey = SecretKeyValues.First();

                if (HttpContext.Current.Application["SecretKey"].ToString() == SecretKey)
                {
                    KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();

                   TResult result = kullaniciIslemleri.GetPersonDetail(Token, SecretKey);
                    if (!result.Success)
                    {
                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        httpResponseMessage = Request.CreateResponse<TResult>(HttpStatusCode.OK, result);
                    }

                }

            }

            return httpResponseMessage;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(TKullaniciKisiAdresRol kullaniciKisiAdresRol)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
           // httpResponseMessage.StatusCode = HttpStatusCode.MethodNotAllowed;

            Business.KullaniciIslemleri kullaniciIslemleri = new Business.KullaniciIslemleri();
          TResult result  =  kullaniciIslemleri.Register(kullaniciKisiAdresRol);

            if (result.Success)
            {
                HttpResponseMessage response =   Request.CreateResponse<TResult>(HttpStatusCode.OK,result);

                httpResponseMessage = response;
            }

            return httpResponseMessage;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}