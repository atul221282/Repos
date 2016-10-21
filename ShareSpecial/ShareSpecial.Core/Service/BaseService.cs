using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ShareSpecial.Core.Extension;
using System;
using Plugin.Geolocator.Abstractions;

namespace ShareSpecial.Core.Service
{
    public abstract class BaseService
    {
        protected readonly IHelperFactory HelperFactory;

        private async Task<HttpClient> GetClient(bool isAuthorised)
            => await HelperFactory.HttpClient.GetClient(isAuthorised);

        protected BaseService(IHelperFactory helperFactory)
        {
            this.HelperFactory = helperFactory;
        }

        protected async Task<Result<T>> Get<T>(string url, bool isAuthorised = true)
        {
            Result<T> result;
            HttpClient client;
            try
            {
                client = await GetClient(isAuthorised: true);
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

        protected async Task<Result<T>> Post<T>(T content, string url, bool isAuthorised = true)
        {
            Result<T> result;
            HttpClient client;
            try
            {
                client = await GetClient(isAuthorised);
                using (client)
                {
                    result = await client.PostJsonAsync<T>(url, content);
                }
            }
            catch (Exception ex)
            {
                result = Result.Error<T>(HttpStatusCode.Unauthorized, "Please login");
            }
            return result;
        }

        protected async Task<Result<TOut>> Post<TIn, TOut>(TIn content, string url, bool isAuthorised = true)
        {
            Result<TOut> result;
            HttpClient client;
            try
            {
                client = await GetClient(isAuthorised);
                using (client)
                {
                    result = await client.PostJsonAsync<TOut, TIn>(url, content);
                }
            }
            catch (Exception ex)
            {
                result = Result.Error<TOut>(HttpStatusCode.Unauthorized, "Please login");
            }
            return result;
        }
    }
}
