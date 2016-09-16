using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ShareSpecial.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Helper
{
    public static class Settings
    {

        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        const string CountKey = "count";
        private static readonly int CountDefault = 0;



        #endregion



        public static int Count
        {
            get { return AppSettings.GetValueOrDefault<int>(CountKey, CountDefault); }
            set { AppSettings.AddOrUpdateValue<int>(CountKey, value); }
        }

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
    }
}
