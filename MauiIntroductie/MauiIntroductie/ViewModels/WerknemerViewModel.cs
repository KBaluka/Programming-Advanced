using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;

namespace MauiIntroductie.ViewModels
{
    public partial class WerknemerViewModel: BaseViewModel
    {
        [ObservableProperty]
        Werknemer werknemer;

        [ObservableProperty]
        ObservableCollection<Werknemer> werknemers;

        public WerknemerViewModel()
        {
            this.Title = "Werknemer toevoegen";
            this.Werknemers = [];
            this.Werknemer = new Werknemer();
        }

        [RelayCommand]
        private void WerknemerToevoegen()
        {
            this.Werknemers.Add(this.Werknemer);
            this.Werknemer = new Werknemer();
        }
        
        // Werknemer jef = new Werknemer();
        // Werknemer jos = jef;
        // jos.Voornaam = "Jos"
        // == jef.Voornaam = "Jos"
    }
}
