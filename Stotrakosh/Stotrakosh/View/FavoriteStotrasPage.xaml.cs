using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stotrakosh
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoriteStotrasPage : ContentPage
	{
		public FavoriteStotrasPage ()
		{
			InitializeComponent ();
		}
        
        void OnSettingsTap(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SettingsPage());
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