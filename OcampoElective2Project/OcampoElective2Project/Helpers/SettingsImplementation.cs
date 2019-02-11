    using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace OcampoElective2Project.Helpers
{
    public static class SettingsImplementation
    {
        private static ISettings AppSettings =>
            CrossSettings.Current;
        public static string User
        {
            get => AppSettings.GetValueOrDefault(nameof(User), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(User), value);
        }
        public static bool IsLoggedIn
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLoggedIn), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsLoggedIn), value);
        }
    }
}
