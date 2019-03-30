﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public static class FavoriteStotrasPageViewModel
    {
        public static ObservableCollection<Stotra> Stotras { get; set; }

        static FavoriteStotrasPageViewModel()
        {
            AllStotrasPageViewModel.Stotras = DataSource.GetStotras();
        }

        public static void UpdateStotras()
        {
            AllStotrasPageViewModel.Stotras.Clear();
            ObservableCollection<Stotra> currentStotras = DataSource.GetStotras();
            foreach (Stotra item in currentStotras)
            {
                Stotras.Add(item);
            }
        }
    }
}