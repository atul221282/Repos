using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using Thinktecture.IdentityModel.Client;
using ShareSpecial.Core.Helper;
using ShareSpecial.Core.Extension;
using ShareSpecial.BusinessEntity.Identity;
using ShareSpecial.Core.Constant;

namespace ShareSpecial.Core.Service
{
    public class HttpClientService : IHttpClientService
    {
        readonly HttpClient client;
        private readonly ISettingResolver setting;

        public HttpClientService(ISettingResolver setting)
        {
            this.client = new HttpClient();
            this.client.Timeout = TimeSpan.FromSeconds(10);
            this.setting = setting;
        }

        public HttpClient GetClient(bool authorize = true, string requestedVersion = null)
        {
            return client;
        }

    }

    public interface IHttpClientService
    {

        HttpClient GetClient(bool authorize = true, string requestedVersion = null);
    }
}