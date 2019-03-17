using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public class SettingsPageViewModel
    {
        public IList<UInt16> FontSizes { get { return UserPreferences.GetFontSizes(); } }
        public IList<string> Languages { get { return UserPreferences.GetLanguages(); } }

        UInt16 selectedFontSize = Settings.FontSize;
        string selectedLanguage = Settings.Language;

        public UInt16 SelectedFontSize
        {
            get { return selectedFontSize; }
            set
            {
                if (selectedFontSize != value)
                {
                    selectedFontSize = value;
                    //OnPropertyChanged();
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
                    //OnPropertyChanged();
                }
            }
        }
    }
}
