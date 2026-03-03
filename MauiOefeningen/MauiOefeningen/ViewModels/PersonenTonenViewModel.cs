using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MauiOefeningen.Models;

namespace MauiOefeningen.ViewModels;

public partial class PersonenTonenViewModel : BaseViewModel
{
    public ObservableCollection<Persoon> Personen { get; }
    [ObservableProperty] 
    int aantal, gemiddeldeLeeftijd;
    public PersonenTonenViewModel(ObservableCollection<Persoon> personen)
    {
        Title = "Personen tonen";
        Personen = personen;
        Aantal = Personen.Count;
        GemiddeldeLeeftijd = BerekenGemiddeldeLeeftijd();
    }
    int BerekenGemiddeldeLeeftijd()
    {
        if (Personen.Count == 0) return 0;
        var leeftijden = Personen.Select(p =>
        {
            int age = DateTime.Today.Year - p.Geboortedatum.Year;
            if (p.Geboortedatum.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        });
        return (int)Math.Round(leeftijden.Average());
    }
}