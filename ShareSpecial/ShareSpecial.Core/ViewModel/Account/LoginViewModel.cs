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
    }
}
