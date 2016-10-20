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
        private readonly ITokenHelper token;
        public HttpClientResolver(ISettingResolver setting, ITokenHelper token)
        {
            this.Setting = setting;
            this.token = token;
        }

        public async Task<HttpClient> GetClient(bool isAuthorised = true)
        {

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(25);

            if (isAuthorised)
                await CheckAndPossiblyRefreshToken(client);

            if (Setting.Token != null && Setting.Token.access_token != null && isAuthorised == true)
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
            if (token.HasExpired())
            {
                try
                {
                    var result = await client.PostJsonAsync<Token>($"{ApplicationConstant.AccountAPI}RefreshToken", Setting.Token);
                    if (result.HasSuccess)
                    {
                        var token = result.Value;
                        //token.CreatedOn = DateTime.Now.AddSeconds(token.expires_in);
                        Settings.TokenExpiry = DateTime.Now.AddSeconds(token.expires_in).ToString();
                        Setting.Token = token;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
