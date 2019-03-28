using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public class SettingsPageViewModel
    {
        public IList<string> FontSizes { get { return UserPreferences.GetFontSizes(); } }
        public IList<string> Languages { get { return UserPreferences.GetLanguages(); } }

        string selectedFontSize = Converter.DoubleToString(Settings.FontSize);
        string selectedLanguage = Settings.Language;

        public string SelectedFontSize
        {
            get { return selectedFontSize; }
            set
            {
                if (selectedFontSize != value)
                {
                    selectedFontSize = value;
                    Settings.FontSize = Converter.StringToDouble(value);
                }
            }
        }

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                if (selectedLanguage != value)
                {
                    selectedLanguage = value;
                    Settings.Language = value;
                }
            }
        }
    }
}
