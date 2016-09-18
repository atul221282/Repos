using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity.Identity;

namespace ShareSpecial.Core.Helper
{
    public interface ISettingResolver
    {
        string BaseAPI { get; }

        string PostSpecialAPI { get; }

        Token Token { get; set; }

        Users User { get; set; }

        PostLocation Location { get; set; }

    }
}
