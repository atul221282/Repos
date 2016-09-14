using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
{
    public interface IResult
    {
        bool HasSuccess { get; set; }
        bool HasError { get; set; }
        string Errors { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        Result Ok<T>(T value);
        Result Error(string error = "", string code = "");
    }
}
