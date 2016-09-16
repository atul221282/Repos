using ShareSpecial.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity.Identity;
using Newtonsoft.Json;

namespace ShareSpecial.Helper
{
    public class SettingResolver : ISettingResolver
    {
        public string BaseAPI => ApplicationConstant.BaseAPI;

        public Token Token
        {
            get
            {
                return JsonConvert.DeserializeObject<Token>(Settings.TokenResponse);
            }

            set
            {
                Settings.TokenResponse = JsonConvert.SerializeObject(value);
            }
        }

        public Users User
        {
            get
            {
                return JsonConvert.DeserializeObject<Users>(Settings.UserDetails);
            }

            set
            {
                Settings.UserDetails = JsonConvert.SerializeObject(value);
            }
        }

    }
}
