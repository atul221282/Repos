using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public class HttpClientResolver : IHttpClientResolver
    {
        public HttpClientResolver()
        {
        }

        public HttpClient GetClient()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(25);
            return client;
        }


    }
}
