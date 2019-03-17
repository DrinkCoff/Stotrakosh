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

        public static IList<UInt16> GetFontSizes()
        {
            List<UInt16> fontSizes = new List<UInt16>()
            {
                10,
                12,
                14,
                16,
                18,
                30
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
