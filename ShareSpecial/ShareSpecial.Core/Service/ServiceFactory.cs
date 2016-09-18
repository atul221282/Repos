using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public class ServiceFactory : IServiceFactory
    {
        
        public ServiceFactory(IAccountService account, ISpecialService special)
        {
            this.Account = account;
            this.Special = special;
        }

        public IAccountService Account { get; }

        public ISpecialService Special { get; }
    }
}
