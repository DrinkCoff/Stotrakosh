using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public class DetailPageViewModel
    {
        public Stotra CurrentStotra { get; set; }
        
        public DetailPageViewModel(Stotra stotra)
        {
            this.CurrentStotra = stotra;
        }
    }
}
