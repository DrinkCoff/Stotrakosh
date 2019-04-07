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
    public partial class MainPage : TabbedPage
    {
        public MainPage ()
        {
            InitializeComponent();
        }

        void OnSettingsTap(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SettingsPage());
        }
    }
}