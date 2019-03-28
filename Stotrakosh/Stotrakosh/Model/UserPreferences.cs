using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public static class UserPreferences
    {
        static UserPreferences()
        {
        }

        public static IList<string> GetFontSizes()
        {
            List<string> fontSizes = new List<string>()
            {
                "Micro",
                "Small",
                "Medium",
                "Large"
            };

            return fontSizes;
        }

        public static IList<string> GetLanguages()
        {
            List<string> languages = new List<string>()
            {
                "संस्कृत (Sanskrit)",
                "ગુજરાતી (Gujarati)",
                "English"
            };

            return languages;
        }
    }
}
