using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
{
    public interface IBaseCode
    {
        string Code { get; set; }
        string Description { get; set; }
    }
}
