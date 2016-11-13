using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Extension;
using ShareSpecial.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public class SpecialService : BaseService, ISpecialService
    {
        public SpecialService(IHelperFactory helperFactory) : base(helperFactory)
        {
        }

        public string GetName() => "I am from special service";

        public async Task<Result<List<PostSpecial>>> GetSpecialsAsync(double? longitude, double? latitude,
            int distance)
        {
            return await Get<List<PostSpecial>>($@"{HelperFactory.Setting.PostSpecialAPI}GetPostSpecial?longitude={longitude}&latitude={latitude}&distance={distance}"
                ,isAuthorised: true);
        }

        public async Task<Result<PostSpecial>> GetSpecialAsync(long id)
        {
            return await Get<PostSpecial>(
                        $"{HelperFactory.Setting.PostSpecialAPI}GetPostSpecial?id={id}",
                        isAuthorised: true);
        }
    }
}
