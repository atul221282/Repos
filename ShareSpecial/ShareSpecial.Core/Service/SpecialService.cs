using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Extension;
using ShareSpecial.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public class SpecialService : ISpecialService
    {

        private readonly IHelperFactory HelperFactory;
        private readonly IResult Result;
        public SpecialService(IHelperFactory helperFactory, IResult result)
        {
            HelperFactory = helperFactory;
            Result = result;
        }

        public void AddSpecial()
        {
            throw new NotImplementedException();
        }

        public string GetName() => "I am from special service";

        public async Task<Result<List<PostSpecial>>> GetSpecialsAsync(double? longitude, double? latitude,
            int distance)
        {
            using (HttpClient client = HelperFactory.HttpClient.GetClient())
            {
                try
                {
                    var response = await client
                        .GetModel<Result<List<PostSpecial>>>(
                        $"{HelperFactory.Setting.PostSpecialAPI}GetPostSpecial?longitude={longitude}&latitude={latitude}&distance={distance}");

                    if (response.HasSuccess)
                        return response;
                    else
                        return Result.Error<List<PostSpecial>>("Error");
                }
                catch (Exception ex)
                {
                    return Result.Error<List<PostSpecial>>(ex.Message);
                }
            }
        }

        public async Task<Result<PostSpecial>> GetSpecialAsync(long id)
        {
            using (HttpClient client = HelperFactory.HttpClient.GetClient())
            {
                try
                {
                    var response = await client
                        .GetModel<Result<PostSpecial>>(
                        $"{HelperFactory.Setting.PostSpecialAPI}GetPostSpecial?id={id}");

                    if (response.HasSuccess)
                        return response;
                    else
                        return Result.Error<PostSpecial>("Error");
                }
                catch (Exception ex)
                {
                    return Result.Error<PostSpecial>(ex.Message);
                }
            }
        }

    }
}
