using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntity.Extension
{
    public static class StringHelper
    {
        public static bool HasValue(this string value) => !string.IsNullOrWhiteSpace(value);

        public static bool HasNoValue(this string value) => !value.HasValue();

        public static long? AsLong(this string value)
        {
            long id;
            var result = long.TryParse(value, out id);
            if (result)
                return id;
            else
                return null;
        }

        public static string ToCamelCase(this string source)
        {
            if (source.HasNoValue())
                return string.Empty;

            return string.Join(" ", Regex.Split(source, @"(?<!^)(?=[A-Z])"));
        }
    }
}
