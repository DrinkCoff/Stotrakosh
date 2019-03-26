// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.IO;

namespace Stotrakosh
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string FontSizeKey = "fontSizeKey";
        private static readonly double FontSizeDefault = 16.0;

        private const string LanguageKey = "languageKey";
        private static readonly string LanguageDefault = "संस्कृत (Sanskrit)";

        private const string DatabasePathKey = "databasePathKey";
        private static readonly string DatabasePathDefault = "";

        #endregion

        public static double FontSize
        {
            get
            {
                return Convert.ToDouble(AppSettings.GetValueOrDefault(FontSizeKey, FontSizeDefault));
            }
            set
            {
                AppSettings.AddOrUpdateValue(FontSizeKey, value);
            }
        }

        public static string Language
        {
            get
            {
                return AppSettings.GetValueOrDefault(LanguageKey, LanguageDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LanguageKey, value);
            }
        }

        public static string DatabaseDirectory
        {
            get
            {
                return AppSettings.GetValueOrDefault(DatabasePathKey, DatabasePathDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DatabasePathKey, value);
            }
        }
    }
}