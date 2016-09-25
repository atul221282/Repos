using Newtonsoft.Json;
using ShareSpecial.BusinessEntity.Identity;
using ShareSpecial.Core.Constant;
using ShareSpecial.Core.Extension;
using ShareSpecial.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public class HttpClientResolver : IHttpClientResolver
    {
        private readonly ISettingResolver setting;
        public HttpClientResolver(ISettingResolver setting)
        {
            this.setting = setting;
        }

        public async Task<HttpClient> GetClient(bool isAuthorised = true)
        {

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(25);

            if (isAuthorised && setting.Token.HasExpired)
                await CheckAndPossiblyRefreshToken(client);

            if (setting.Token.access_token != null && isAuthorised == true)
            {
                client.SetBearerToken(setting.Token.access_token);
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task CheckAndPossiblyRefreshToken(HttpClient client)
        {
            try
            {
                var result = await client.PostStringAsync<Token>($"{ApplicationConstant.AccountAPI}RefreshToken", setting.Token);
                if (result.IsSuccessStatusCode)
                {
                    setting.Token = JsonConvert.DeserializeObject<Token>(await result.Content.ReadAsStringAsync());
                    setting.Token.CreatedOn = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                var gg = ex;
            }
        }
    }
}
