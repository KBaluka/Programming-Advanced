using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.ViewModels;
public partial class VakViewModel : ObservableObject
{
    [ObservableProperty]
    string voornaam, naam, campus, lokaal, uitvoer;
    [ObservableProperty] 
    bool vastLokaal;
    [ObservableProperty] 
    DateTime datumEersteLes;
    [ObservableProperty] 
    double score;
    public VakViewModel()
    {
        Voornaam = string.Empty;
        Naam = string.Empty;
        Campus = string.Empty;
        Lokaal = string.Empty;
        VastLokaal = false;
        DatumEersteLes = DateTime.Today;
        Score = 0;
        Uitvoer = string.Empty;
    }
    [RelayCommand]
    public void Opslaan()
    {
        var s = $"Welkom {Voornaam} {Naam}\n";
        if (VastLokaal)
            s += $"Je vast lokaal is {Lokaal} in {Campus}\n";
        s += $"Je eerste les is op {DatumEersteLes:dd/MM/yyyy}\n";
        s += $"Je hoopt {(int)Score}/20 te scoren";
        Uitvoer = s;
    }
}