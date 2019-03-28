using System;
using System.Collections.Generic;
using System.Text;

namespace Stotrakosh
{
    public static class Converter
    {
        public static double StringToDouble(string fontSize)
        {
            switch (fontSize)
            {
                case "Micro":
                    return 10.0;
                case "Small":
                    return 14.0;
                case "Medium":
                    return 18.0;
                case "Large":
                    return 22.0;
                default:
                    return 18.0;
            }
        }

        public static string DoubleToString(double fontSize)
        {
            switch (fontSize)
            {
                case 10.0:
                    return "Micro";
                case 14.0:
                    return "Small";
                case 18.0:
                    return "Medium";
                case 22.0:
                    return "Large";
                default:
                    return "Medium";
            }
        }
    }
}
