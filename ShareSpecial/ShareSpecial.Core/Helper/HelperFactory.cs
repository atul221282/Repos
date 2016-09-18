using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public class HelperFactory : IHelperFactory
    {
        private readonly IHttpClientResolver client;
        private readonly ISettingResolver setting;

        public HelperFactory(IHttpClientResolver httpClient, ISettingResolver setting)
        {
            this.client = httpClient;
            this.setting = setting;
        }
        public IHttpClientResolver HttpClient => client;

        public ISettingResolver Setting => setting;
    }
}
