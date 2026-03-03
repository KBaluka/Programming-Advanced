using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using MauiOefeningen.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MauiOefeningen.ViewModels;
public partial class GetallenRijViewModel : BaseViewModel
{
    [ObservableProperty]
    int invoer, kleinste, grootste;
    [ObservableProperty] 
    string fout;
    public ObservableCollection<GetalItem> Rij { get; } = new();
    public GetallenRijViewModel()
    {
        Title = "GetallenRij";
        Invoer = 0;
        Kleinste = 0;
        Grootste = 0;
        Fout = "";
    }
    [RelayCommand]
    async Task GetalToevoegen()
    {
        Fout = "";
        if (Invoer > 20)
        {
            await Shell.Current.DisplayAlert("Fout", "Een getal mag niet groter zijn dan 20", "Ok");
            return;
        }
        Rij.Add(new GetalItem { Waarde = Invoer });
        Kleinste = Rij.Min(x => x.Waarde);
        Grootste = Rij.Max(x => x.Waarde);
    }
    [RelayCommand]
    void VerwijderLaatste()
    {
        if (Rij.Count == 0) return;
        Rij.RemoveAt(Rij.Count - 1);
        if (Rij.Count == 0)
        {
            Kleinste = 0;
            Grootste = 0;
            return;
        }
        Kleinste = Rij.Min(x => x.Waarde);
        Grootste = Rij.Max(x => x.Waarde);
    }
}