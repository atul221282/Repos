using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public class AccountService : IAccountService
    {
        public string GetEmail()
        {
            return @"atul221282@gmail.com";
        }

        public bool Validate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
