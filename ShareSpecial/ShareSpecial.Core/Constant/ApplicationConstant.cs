using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Constant
{
    public static class ApplicationConstant
    {
        public const string BaseUrl = @"http://192.168.153.2/";
        public const string BaseAPI = BaseUrl + "PostAnything.API/api/";
    }

    public static class SettingConstant
    {
        public static string skExpiresAt = "expires_at";
        public static DateTime skExpiresAtDefault = DateTime.MinValue;

        public static string skTokenResponse = "token";
        public static string skTokenResponseDefault = string.Empty;

        public static string skUserDetailsKey = "user";
        public static string skUserDetailsDefault = string.Empty;
    }

}
