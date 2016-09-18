using System;

namespace ShareSpecial.Core.Constant
{
    public static class ApplicationConstant
    {
        public const string BaseUrl = @"http://192.168.0.9/";
        public const string BaseAPI = BaseUrl + "PostAnything.API/api/";
        public static string PostSpecialAPI = BaseAPI + "PostSpecials/";
    }

    public static class SettingConstant
    {
        public static string skExpiresAt = "expires_at";
        public static DateTime skExpiresAtDefault = DateTime.MinValue;

        public static string skTokenResponse = "token";
        public static string skTokenResponseDefault = string.Empty;

        public static string skUserDetailsKey = "user";
        public static string skUserDetailsDefault = string.Empty;

        public static string Location = "Location";
        public static string LocationDefault = string.Empty;
    }

}
