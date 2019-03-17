using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Stotrakosh
{
    public static class DataSource
    {
        static DataSource()
        {
        }

        public static ObservableCollection<Stotra> GetStotras()
        {
            ObservableCollection<Stotra> stotras = DatabaseOp.GetStotrasFromDb();
            return stotras;
        }
    }
}
