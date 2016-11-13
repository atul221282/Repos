using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntity.Identity
{
    public class Token
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string token_type { get; set; }

        public string refresh_token { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTimeOffset expires_at { get; set; }

        public DateTimeOffset issued_at { get; set; }
    }
}
