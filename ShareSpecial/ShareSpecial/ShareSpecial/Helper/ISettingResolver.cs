using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Helper
{
    public interface ISettingResolver
    {
        string BaseAPI { get; }

        Token Token { get; set; }

        Users User { get; set; }
    }
}
