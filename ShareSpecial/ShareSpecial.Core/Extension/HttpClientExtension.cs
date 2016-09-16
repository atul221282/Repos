using Newtonsoft.Json;
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
        public static Task<HttpResponseMessage> PostStringAsync<T>(this HttpClient client, string url, T model)
        {
            return client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
        }

        public static async Task<T> GetModel<T>(this HttpClient client, string url)
        {
            T value = JsonConvert.DeserializeObject<T>(await client.GetStringAsync(url));
            return await Task.FromResult(value);
        }
    }
}
