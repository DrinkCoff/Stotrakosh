using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public static class MainPageViewModel
    {
        public static ObservableCollection<Stotra> Stotras { get; set; }

        static MainPageViewModel()
        {
            MainPageViewModel.Stotras = DataSource.GetStotras();
        }
    }
}
