using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.ViewModels;
public partial class NaamTonenViewModel : ObservableObject
{
    [ObservableProperty] 
    string naam, resultaat;
    [ObservableProperty] 
    double aantal;
    public NaamTonenViewModel()
    {
        Naam = "";
        Aantal = 0;
        Resultaat = "Resultaat:";
        Leegmaken();
    }
    [RelayCommand]
    void NaamTonen()
    {
        var n = (int)Aantal;
        if (n <= 0 || string.IsNullOrWhiteSpace(Naam))
        {
            Resultaat = "Resultaat:";
            return;
        }
        var list = new List<string>();
        for (int i = 0; i < n; i++)
            list.Add(Naam);
        Resultaat = $"Resultaat: {string.Join(", ", list)}";
    }
    [RelayCommand]
    void ResultaatLeegmaken()
    {
        Leegmaken();
    }
    void Leegmaken()
    {
        Naam = "";
        Aantal = 0;
        Resultaat = "Resultaat:";
    }
}