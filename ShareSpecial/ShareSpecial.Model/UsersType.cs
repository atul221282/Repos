using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
{
    public class UsersType : BaseCode
    {
        //public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<UsersUsersType> UsersUsersTypes { get; set; }
    }
}
