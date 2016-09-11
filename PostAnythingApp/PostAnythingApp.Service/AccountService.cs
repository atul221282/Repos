using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostAnythingApp.Service
{
    public class AccountService : IAccountService
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public AccountService()
        {
            this.Id = 1;
            this.UserName = "Atul";
        }
    }

    public interface IAccountService
    {
        long Id { get; set; }

        string UserName { get; set; }
    }
}
