using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public class TokenHelper : ITokenHelper
    {
        public bool HasExpired() => DateTime.Now.ToLocalTime() >= DateTime.Parse(Settings.TokenExpiry);
    }
}
