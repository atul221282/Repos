using ShareSpecial.BusinessEntity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntity
{
    public class Result : IResult
    {
        public string Code { get; set; }

        public HttpStatusCode HttpCode { get; set; } = HttpStatusCode.OK;
        public string Description { get; set; }

        public string Errors { get; set; }

        public bool HasError { get; set; }

        public bool HasSuccess { get; set; }

        public Exception Excpetion { get; set; }

        public static Result Error(string error = "", string code = "")
        {
            return new Result
            {
                Code = code,
                Errors = error,
                HasError = true
            };
        }

        public static Result<T> Error<T>(string error = "", string code = "")
        {
            return new Result<T>
            {
                Code = code,
                Errors = error,
                HasError = true,
                HttpCode = HttpStatusCode.InternalServerError
            };
        }

        public static Result Error(HttpStatusCode code, string error = "")
        {
            return new Result
            {
                Code = code.ToString(),
                HttpCode = code,
                Errors = error ?? code.ToString().ToCamelCase(),
                HasError = true
            };
        }

        public static Result<T> Error<T>(HttpStatusCode code, string error = "")
        {
            return new Result<T>
            {
                Code = code.ToString(),
                HttpCode = code,
                Errors = error ?? code.ToString().ToCamelCase(),
                HasError = true
            };
        }

        public static Result Error(Exception ex)
        {
            return new Result
            {
                Excpetion = ex,
                Errors = ex.Message,
                HasError = true
            };
        }

        public static Result<T> Error<T>(Exception ex)
        {
            return new Result<T>
            {
                Excpetion = ex,
                Errors = ex.Message,
                HasError = true
            };
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>
            {
                HasSuccess = true,
                Value = value,
            };
        }
    }
}
