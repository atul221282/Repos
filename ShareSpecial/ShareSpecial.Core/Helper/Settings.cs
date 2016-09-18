using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ShareSpecial.Core.Constant;

namespace ShareSpecial.Core.Helper
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string User
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.skUserDetailsKey, SettingConstant.skUserDetailsDefault); }
            set { AppSettings.AddOrUpdateValue<string>(SettingConstant.skUserDetailsKey, value); }
        }

        public static string Token
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.skTokenResponse, SettingConstant.skTokenResponseDefault); }
            set { AppSettings.AddOrUpdateValue<string>(SettingConstant.skTokenResponse, value); }
        }

        public static string Location
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.Location, SettingConstant.LocationDefault); }
            set { AppSettings.AddOrUpdateValue<string>(SettingConstant.Location, value); }
        }
    }
}
