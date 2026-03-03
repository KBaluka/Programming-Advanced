using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.ViewModels;
public partial class AfbeeldingenViewModel : ObservableObject
{
    [ObservableProperty] 
    double geselecteerdGetal;
    [ObservableProperty]
    string afbeeldingBron;
    public AfbeeldingenViewModel()
    {
        GeselecteerdGetal = 1;
        AfbeeldingBron = "";
    }
    [RelayCommand]
    void AfbeeldingTonen()
    {
        var n = (int)GeselecteerdGetal;
        AfbeeldingBron = $"landschap{n}.jpg";
    }
}