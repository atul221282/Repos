
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ShareSpecial.Core.Constant;
using System;

namespace ShareSpecial.Core.Helper
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string UserDetails
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skUserDetailsKey, SettingConstants.skUserDetailsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skUserDetailsKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the token response.
        /// </summary>
        /// <value>
        /// The token response.
        /// </value>
        public static string TokenResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skTokenResponse,
                    SettingConstants.skTokenResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skTokenResponse, value);
            }
        }

        /// <summary>
        /// Gets or sets the token response.
        /// </summary>
        /// <value>
        /// The token response.
        /// </value>
        public static DateTime ExpiresAt
        {
            get
            {
                return AppSettings.GetValueOrDefault<DateTime>(SettingConstants.skExpiresAt,
                    SettingConstants.skExpiresAtDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<DateTime>(SettingConstants.skExpiresAt, value);
            }
        }

    }
}