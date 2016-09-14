using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
{
    public class Result : IResult
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string Errors { get; set; }

        public bool HasError { get; set; }

        public bool HasSuccess { get; set; }

        public Result Error(string error = "", string code = "")
        {
            return new Result
            {
                Code = code,
                Errors = error,
                HasError = true
            };
        }

        public Result Ok<T>(T value)
        {
            return new Result<T>
            {
                HasSuccess = true,
                Value = value,
            };
        }
    }
}
