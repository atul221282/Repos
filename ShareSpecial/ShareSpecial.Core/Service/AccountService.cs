using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public class AccountService : IAccountService
    {
        private const string Email = "";
        public string GetEmail() => Email;

        public bool Validate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
