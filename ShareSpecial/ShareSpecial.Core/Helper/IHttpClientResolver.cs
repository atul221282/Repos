using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public interface IHttpClientResolver
    {
        HttpClient GetClient();
    }
}
