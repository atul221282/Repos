using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity;
using ShareSpecial.BusinessEntity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.ViewModel.Account
{
    public interface ILoginViewModel
    {
        string Email { get; set; }
        string Password { get; set; }

        string GetEmail();

        Task<Result<Tuple<Token, Users>>> LoginAsync();
    }
}
