using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
{
    public class Permission : BaseEntity
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
