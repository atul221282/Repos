using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ShareSpecial.Core.Extension;
using Newtonsoft.Json;

namespace ShareSpecial.Core.Service
{
    public abstract class BaseService
    {
        protected readonly IHelperFactory HelperFactory;
        protected BaseService(IHelperFactory helperFactory)
        {
            this.HelperFactory = helperFactory;
        }
        protected async Task<Result<T>> Get<T>(string url, bool isAuthorised)
        {
            Result<T> result;
            HttpClient client;
            try
            {
                client = await HelperFactory.HttpClient.GetClient(isAuthorised: true);
                using (client)
                {
                    result = await client.GetAsync<T>(url);
                }
            }
            catch
            {
                result = Result.Error<T>(HttpStatusCode.Unauthorized, "Please login");
            }
            return result;
        }
    }
}
