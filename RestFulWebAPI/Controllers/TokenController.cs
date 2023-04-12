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
    public class TokenController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post(TUser user)
        {
            IEnumerable<string> values;
            HttpResponseMessage Response = new HttpResponseMessage();
            Response.StatusCode = HttpStatusCode.Unauthorized;

           bool GetSecretKey = Request.Headers.TryGetValues("SecretKey",out values);
            if (GetSecretKey)
            {
                string SecretKey = values.First();
              

                //if (HttpContext.Current.Application["SecretKey"].ToString() == SecretKey)
                //{
                    KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();
                    TResult result = kullaniciIslemleri.GetToken(user.KullaniciAdi, user.Sifre, SecretKey);
                    if (!result.Success)
                    {
                        Response = Request.CreateResponse( HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        Response = Request.CreateResponse<TResult>(HttpStatusCode.OK,result);
                    }

               // }

            }
            

            return Response;
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