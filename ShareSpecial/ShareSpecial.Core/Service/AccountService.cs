using Newtonsoft.Json;
using ShareSpecial.Core.Helper;
using ShareSpecial.Core.Extension;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ShareSpecial.BusinessEntity.Identity;
using ShareSpecial.BusinessEntities;
using System;

namespace ShareSpecial.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly ISettingResolver Setting;
        private readonly IHttpClientResolver Client;
        public AccountService(ISettingResolver setting, IHttpClientResolver client)
        {
            this.Setting = setting;
            Client = client;
        }

        private const string Email = "";

        public string GetEmail() => Email;

        public async Task<bool> LoginAsync(string email, string password)
        {
            using (var client = Client.GetClient())
            {
                var response = await client
                    .PostStringAsync<object>($"{Setting.BaseAPI}Account/Login",
                    new { EmailAddress = email, password = password });
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                    var token = result["m_Item1"].ToObject<Token>();
                    var user = result["m_Item2"].ToObject<Users>();
                    return true;
                }
                return false;
            }
        }
    }
}
