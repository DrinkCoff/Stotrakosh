﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stotrakosh
{
    public partial class AllStotrasPage : ContentPage
    {
        public AllStotrasPage()
        {
            InitializeComponent();
        }

        void OnFavoriteTap(object sender, EventArgs e)
        {
            string stotraName = ((ImageButton)sender).CommandParameter.ToString();

            DatabaseOp.UpdateIsFavorite(stotraName);

            listView.ItemsSource = DataSource.GetStotras();
        }

        void StotraSelection(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PushAsync(new DetailPage((Stotra)((ListView)sender).SelectedItem));
        }

        protected override void OnAppearing()
        {
            listView.ItemsSource = DataSource.GetStotras();
            base.OnAppearing();
        }
    }
}
