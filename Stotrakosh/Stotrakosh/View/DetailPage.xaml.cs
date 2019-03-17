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
	public partial class DetailPage : ContentPage
	{

        public DetailPage (Stotra stotra)
		{
            InitializeComponent ();
            BindingContext = new DetailPageViewModel(stotra);
        }
    }
}