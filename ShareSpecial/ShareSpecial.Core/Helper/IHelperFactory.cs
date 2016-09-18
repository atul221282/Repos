using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public interface IHelperFactory
    {
        IHttpClientResolver HttpClient { get; }

        ISettingResolver Setting { get; }

    }
}
