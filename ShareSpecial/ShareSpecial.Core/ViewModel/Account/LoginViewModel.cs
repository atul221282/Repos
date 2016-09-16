﻿using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity;
using ShareSpecial.BusinessEntity.Identity;
using ShareSpecial.Core.Helper;
using ShareSpecial.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.ViewModel.Account
{
    public class LoginViewModel : ILoginViewModel
    {

        private readonly IAccountService Service;

        public LoginViewModel(IAccountService service)
        {
            this.Service = service;
            this.Email = service.GetEmail();
        }
        public string Email { get; set; }

        public string Password { get; set; }

        public string GetEmail() => $"{Email} welcome to xamarin";

        public async Task<Result<Tuple<Token,Users>>> LoginAsync() => await Service.LoginAsync(Email, Password);
    }
}
