using ShareSpecial.Core.Constant;
using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity.Identity;
using Newtonsoft.Json;
using ShareSpecial.BusinessEntities.Post;

namespace ShareSpecial.Core.Helper
{
    public class SettingResolver : ISettingResolver
    {
        public string BaseAPI => ApplicationConstant.BaseAPI;

        public string PostSpecialAPI => ApplicationConstant.PostSpecialAPI;

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

        public PostLocation Location
        {
            get
            {
                return JsonConvert.DeserializeObject<PostLocation>(Settings.Location);
            }

            set
            {
                Settings.Location = JsonConvert.SerializeObject(value);
            }
        }

    }
}
