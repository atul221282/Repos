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
        private readonly ISettingResolver Setting;
        public HttpClientResolver(ISettingResolver setting)
        {
            this.Setting = setting;
        }

        public async Task<HttpClient> GetClient(bool isAuthorised = true)
        {

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(25);

            if (isAuthorised)
                await CheckAndPossiblyRefreshToken(client);

            if (Setting.Token.access_token != null && isAuthorised == true)
            {
                client.SetBearerToken(Setting.Token.access_token);
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task CheckAndPossiblyRefreshToken(HttpClient client)
        {
            if (DateTime.Now.ToLocalTime() >= Setting.Token.CreatedOn)
            {
                try
                {
                    var result = await client.PostStringAsync<Token>($"{ApplicationConstant.AccountAPI}RefreshToken", Setting.Token);
                    if (result.IsSuccessStatusCode)
                    {
                        var token = JsonConvert.DeserializeObject<Token>(await result.Content.ReadAsStringAsync());
                        token.CreatedOn = DateTime.Now.AddSeconds(token.expires_in);
                        Setting.Token = token;
                    }
                }
                catch (Exception ex)
                {
                    var gg = ex;
                }
            }
        }
    }
}
