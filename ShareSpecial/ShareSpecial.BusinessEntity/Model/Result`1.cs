using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntity
{
    public class Result<T> : Result
    {
        public T Value { get; set; }
    }
}
