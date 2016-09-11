using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostAnythingApp.Service
{
    public class MainPageModel : IMainPageModel
    {
        private readonly IAccountService Account;
        public MainPageModel(IAccountService account)
        {
            this.Account = account;
            this.Name = account.UserName;
        }
        public string Name { get; set; }
    }

    public interface IMainPageModel
    {
        string Name { get; set; }
    }
}
