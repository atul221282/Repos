using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntities
{
    public class UsersUsersType : BaseEntity
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public long UsersTypeId { get; set; }
        public virtual UsersType UsersType { get; set; }
    }
}
