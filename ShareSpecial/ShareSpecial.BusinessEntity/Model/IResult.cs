using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntity
{
    public interface IResult
    {
        bool HasSuccess { get; set; }
        bool HasError { get; set; }
        string Errors { get; set; }
        string Code { get; set; }
        string Description { get; set; }

    }
}
