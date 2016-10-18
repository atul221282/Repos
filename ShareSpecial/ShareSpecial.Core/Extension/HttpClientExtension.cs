using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShareSpecial.BusinessEntity;
using ShareSpecial.BusinessEntity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Extension
{
    public static class HttpClientExtensions
    {
        public static async Task<Result<T>> GetAsync<T>(this HttpClient client, string url)
        {
            try
            {
                var data = await client.GetAsync(url);

                if (data.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Result<T>>(await data.Content.ReadAsStringAsync());
                }
                return await Error<T>(data);
            }
            catch (Exception ex)
            {
                return Result.Error<T>(ex);
            }
        }

        public static async Task<Result<T>> PostJsonAsync<T>(this HttpClient client, string url, T content)
        {
            using (var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"))
            {
                try
                {
                    var data = await client.PostAsync(url, stringContent);

                    if (data.IsSuccessStatusCode)
                    {
                        return Result.Ok(JsonConvert.DeserializeObject<T>(await data.Content.ReadAsStringAsync()));
                    }
                    return await Error<T>(data);
                }
                catch (Exception ex)
                {
                    return Result.Error<T>(ex);
                }
            }
        }

        public static async Task<Result<TOut>> PostJsonAsync<TOut, TIn>(this HttpClient client, string url, TIn content)
        {
            using (var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"))
            {
                try
                {
                    var data = await client.PostAsync(url, stringContent);

                    if (data.IsSuccessStatusCode)
                    {
                        return Result.Ok(JsonConvert.DeserializeObject<TOut>(await data.Content.ReadAsStringAsync()));
                    }
                    return await Error<TOut>(data);
                }
                catch (Exception ex)
                {
                    return Result.Error<TOut>(ex);
                }
            }
        }

        private static async Task<Result<TOut>> Error<TOut>(HttpResponseMessage data)
        {
            var content = await data.Content.ReadAsStringAsync();
            var ex = content.HasValue() ? JObject.Parse(content) : GetJObject();
            var message = ex.GetValue("ExceptionMessage") ?? ex.GetValue("Message");
            switch (data.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    return Result.Error<TOut>(data.StatusCode, "Please login");
                default:
                    return Result.Error<TOut>(data.StatusCode, message?.ToString());
            }


        }

        private static JObject GetJObject()
        {
            dynamic result = new JObject();
            result.Message = "An error has occurred";
            return result;
        }
    }
}
