﻿using Newtonsoft.Json;
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
using System.Net;

namespace ShareSpecial.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHelperFactory HelperFactory;
        private readonly IHttpClientService Service;

        public AccountService(IHelperFactory helperFactory, IHttpClientService service)
        {
            HelperFactory = helperFactory;
            Service = service;
        }

        private const string Email = "";

        public string GetEmail() => Email;

        public async Task<Result<Tuple<Token, Users>>> LoginAsync(string email, string password)
        {
            using (HttpClient client = await HelperFactory.HttpClient.GetClient(isAuthorised: false))
            {
                try
                {
                    string url = ApplicationConstant.AccountAPI + "Login";
                    var response = await client
                        .PostJsonAsync<object>(url,
                        new { EmailAddress = email, Password = password });

                    if (response.HasSuccess)
                    {
                        var data = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(response.Value));
                        var user = data["m_Item2"].ToObject<Users>();
                        var token = data["m_Item1"].ToObject<Token>();
                        token.CreatedOn = DateTime.Now.AddSeconds(token.expires_in);
                        return Result.Ok(new Tuple<Token, Users>(token, user));
                    }
                    else
                        return Result.Error<Tuple<Token, Users>>(HttpStatusCode.Unauthorized, "Login Error");
                }
                catch (Exception ex)
                {
                    return Result.Error<Tuple<Token, Users>>(HttpStatusCode.Unauthorized, "Login Error");
                }
            }
        }


    }
}
