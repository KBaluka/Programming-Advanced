using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using MauiOefeningen.Models;

namespace MauiOefeningen.ViewModels;
public partial class PersonenIngevenViewModel : BaseViewModel
{
    [ObservableProperty] 
    string voornaam;
    [ObservableProperty] 
    DateTime geboortedatum;
    public ObservableCollection<Persoon> Personen { get; } = new();
    public PersonenIngevenViewModel()
    {
        Title = "Personen ingeven";
        Voornaam = "";
        Geboortedatum = DateTime.Today;
    }

    [RelayCommand]
    void Ingeven()
    {
        if (string.IsNullOrWhiteSpace(Voornaam)) return;
        Personen.Add(new Persoon
        {
            Voornaam = Voornaam,
            Geboortedatum = Geboortedatum
        });
        Voornaam = "";
        Geboortedatum = DateTime.Today;
    }

    [RelayCommand]
    async Task Tonen()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(Personen);
        var data = Uri.EscapeDataString(json);
        await Shell.Current.GoToAsync($"{nameof(PersonenTonenPage)}?data={data}");
    }
}