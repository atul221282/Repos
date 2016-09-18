
using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.BusinessEntity.Identity;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public interface IAccountService
    {
        string GetEmail();
        Task<Result<Tuple<Token, Users>>> LoginAsync(string email, string password);
        
    }
}
