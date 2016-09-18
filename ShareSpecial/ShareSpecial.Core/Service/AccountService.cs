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
using ShareSpecial.BusinessEntities.Post;
using System.Collections.Generic;

namespace ShareSpecial.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHelperFactory HelperFactory;
        private readonly IResult Result;
        public AccountService(IHelperFactory helperFactory, IResult result)
        {
            HelperFactory = helperFactory;
            Result = result;
        }

        private const string Email = "";

        public string GetEmail() => Email;

        public async Task<Result<Tuple<Token, Users>>> LoginAsync(string email, string password)
        {
            using (HttpClient client = HelperFactory.HttpClient.GetClient())
            {
                try
                {
                    var response = await client
                        .PostStringAsync<object>($"{HelperFactory.Setting.BaseAPI}Account/Login",
                        new { EmailAddress = email, password = password });

                    if (response.IsSuccessStatusCode)
                    {
                        var data = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                        var user = data["m_Item2"].ToObject<Users>();
                        var token = data["m_Item1"].ToObject<Token>();

                        return Result.Ok(new Tuple<Token, Users>(token, user));

                    }
                    else
                        return Result.Error<Tuple<Token, Users>>("Error");
                }
                catch (Exception ex)
                {
                    return Result.Error<Tuple<Token, Users>>(ex.Message);
                }

            }
        }

        
    }
}
