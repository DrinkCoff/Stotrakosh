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
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
            BindingContext = new SettingsPageViewModel();
        }

        private void FontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            //Settings.FontSize = (UInt16)picker.SelectedItem;
        }

        private void Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            //Select = (string)picker.SelectedItem;
        }
    }
}