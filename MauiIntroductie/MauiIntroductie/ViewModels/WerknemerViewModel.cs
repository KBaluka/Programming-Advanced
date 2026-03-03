using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiIntroductie.Models;

namespace MauiIntroductie.ViewModels
{
    public partial class WerknemerViewModel : BaseViewModel
    {
        [ObservableProperty]
        Werknemer werknemer;

        [ObservableProperty]
        ObservableCollection<Werknemer> werknemers;

        [ObservableProperty]
        ObservableCollection<Functie> functies;

        private readonly IWerknemerRepository _werknemerRepository;
        private readonly IFunctieRepository _functieRepository;

        public WerknemerViewModel(IWerknemerRepository werknemerRepository, IFunctieRepository functieRepository)
        {
            this.Title = "Werknemer toevoegen";
            this._werknemerRepository = werknemerRepository;
            this._functieRepository = functieRepository;
            this.Werknemers = new ObservableCollection<Werknemer>(this._werknemerRepository.GetWerknemers());
            this.Functies = new ObservableCollection<Functie>(this._functieRepository.GetFuncties());
            this.Werknemer = new Werknemer();
        }

        //Dit kan je inzetten als je de lijst wilt aanpassen en niet gewoon aan toevoegen
        [RelayCommand]
        private void RefreshLists()
        {
            this.Werknemers = new ObservableCollection<Werknemer>(this._werknemerRepository.GetWerknemers());
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

        [RelayCommand]
        //methode mag niet statisch zijn hier omdat een statisch methode kan geen gebruik maken van deze objact (this.werknemer)
        public async Task GoToDetails()
        {
            Dictionary<string, object> queryParameters = new Dictionary<string, object> { { "WerknemerId", this.Werknemer.Id } };
            await Shell.Current.GoToAsync(nameof(WerknemerDetailPage), true, queryParameters);
        }    
    }
}
