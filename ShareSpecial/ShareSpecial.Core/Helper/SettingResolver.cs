using ShareSpecial.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public class SettingResolver : ISettingResolver
    {
        public string BaseAPI => ApplicationConstant.BaseAPI;
    }
}
