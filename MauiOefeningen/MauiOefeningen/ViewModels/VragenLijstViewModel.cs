using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.ViewModels;

public partial class VragenLijstViewModel : ObservableObject
{
    [ObservableProperty] 
    string naam, selectedEten, selectedDrinken, resultaat;
    [ObservableProperty] 
    bool controlsZichtbaar;
    [ObservableProperty]
    List<string> itemsPicker;
    [ObservableProperty]
    double sportDagen;
    public VragenLijstViewModel()
    {
        ItemsPicker = new List<string> { "Ja", "Nee" };
        Initialiseer();
    }
    public async Task StartAsync()
    {
        await VraagNaamAsync();
    }
    async Task VraagNaamAsync()
    {
        string input = await Shell.Current.DisplayPromptAsync("Naam ingeven", "Geef je naam in.");

        if (string.IsNullOrWhiteSpace(input))
        {
            await Shell.Current.DisplayAlert("Fout", "Je moet verplicht een naam ingeven", "Ok");
            await VraagNaamAsync();
            return;
        }
        Naam = input;
        ControlsZichtbaar = true;
    }
    void Initialiseer()
    {
        Naam = "";
        ControlsZichtbaar = false;
        SelectedEten = null;
        SelectedDrinken = null;
        SportDagen = 0;
        Resultaat = "";
    }
    [RelayCommand]
    async Task Controleren()
    {
        if (SelectedEten == null || SelectedDrinken == null)
        {
            await Shell.Current.DisplayAlert("Fout", "Maak een keuze bij alle vragen", "Ok");
            return;
        }
        string eetTekst = SelectedEten == "Ja" ? "voldoende" : "onvoldoende";
        string drinkTekst = SelectedDrinken == "Ja" ? "voldoende" : "onvoldoende";
        string sportTekst = SportDagen >= 3 ? "voldoende" : "onvoldoende";
        Resultaat =
            $"Je eet {eetTekst}, je drinkt {drinkTekst}, en je sport {sportTekst}.\n";

        if (SelectedEten == "Ja" && SelectedDrinken == "Ja" && SportDagen >= 5)
            Resultaat += $"Je bent in topvorm, {Naam}. Doe zo verder kanjer!";
        else
            Resultaat += $"Voldoende eten, drinken en sporten is belangrijk, {Naam}";
    }
    [RelayCommand]
    async Task Herstarten()
    {
        Initialiseer();
        await VraagNaamAsync();
    }
}