using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareSpecial.Core
{
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel(IAccountService account)
        {
            this.Name = account.Name;
        }
        public string Name { get; set; } = "Hi Atul";
    }

    public interface IMainViewModel
    {
        string Name { get; set; }
    }

    public interface IAccountService
    {
        string Name { get; set; }
    }
    public class AccountService : IAccountService
    {
        public string Name { get; set; } = "I am account service";
    }
}
