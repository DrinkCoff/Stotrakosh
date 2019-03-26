using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stotrakosh
{
    public class DetailPageViewModel
    {
        private Stotra currentStotra;
        public string CurrentStotraLyrics { get { return currentStotra.Lyrics; } }
        public double CurrentFontSize { get { return Settings.FontSize; } }

        public DetailPageViewModel(Stotra stotra)
        {
            this.currentStotra = stotra;
        }
    }
}
