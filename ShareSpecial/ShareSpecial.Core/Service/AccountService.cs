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
using ShareSpecial.Core.Constant;
using ShareSpecial.BusinessEntity;


namespace ShareSpecial.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientResolver Client;
        private readonly IResult Result;
        public AccountService(IHttpClientResolver client, IResult result)
        {
            Client = client;
            Result = result;
        }

        private const string Email = "";

        public string GetEmail() => Email;

        public async Task<Result<Tuple<Token, Users>>> LoginAsync(string email, string password)
        {
            using (var client = Client.GetClient())
            {
                var response = await client
                    .PostStringAsync<object>($"{ApplicationConstant.BaseAPI}Account/Login",
                    new { EmailAddress = email, password = password });
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                    var user = data["m_Item2"].ToObject<Users>();
                    var token = data["m_Item1"].ToObject<Token>();

                    return Result.Ok(new Tuple<Token, Users>(token,user));

                }
                return Result.Error<Tuple<Token, Users>>("Error");
            }
        }

       
    }
}
