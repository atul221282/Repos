using ShareSpecial.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity.Identity;
using Newtonsoft.Json;

namespace ShareSpecial.Core.Helper
{
    public class SettingResolver : ISettingResolver
    {
        public string BaseAPI => ApplicationConstant.BaseAPI;

        public Token Token
        {
            get
            {
                return JsonConvert.DeserializeObject<Token>(Settings.Token);
            }

            set
            {
                Settings.Token = JsonConvert.SerializeObject(value);
            }
        }

        public Users User
        {
            get
            {
                return JsonConvert.DeserializeObject<Users>(Settings.User);
            }

            set
            {
                Settings.User = JsonConvert.SerializeObject(value);
            }
        }

    }
}
