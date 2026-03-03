using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using MauiOefeningen.Models;

namespace MauiOefeningen.ViewModels;
public partial class FactuurViewModel : BaseViewModel
{
    [ObservableProperty] 
    string productNaam;
    [ObservableProperty] 
    decimal prijs, subtotaal, btw, eindtotaal;
    [ObservableProperty] 
    int aantal;
    public ObservableCollection<Product> Producten { get; } = new();

    public FactuurViewModel()
    {
        Title = "Factuur";
        ProductNaam = "";
        Prijs = 0;
        Aantal = 0;
        Subtotaal = 0;
        Btw = 0;
        Eindtotaal = 0;
    }
    [RelayCommand]
    void ProductToevoegen()
    {
        if (string.IsNullOrWhiteSpace(ProductNaam)) return;
        if (Prijs <= 0) return;
        if (Aantal <= 0) return;
        Producten.Add(new Product
        {
            Naam = ProductNaam,
            Prijs = Prijs,
            Aantal = Aantal
        });
        ProductNaam = "";
        Prijs = 0;
        Aantal = 0;
        HerberekenTotaal();
    }
    void HerberekenTotaal()
    {
        Subtotaal = Producten.Sum(p => p.Totaal);
        Btw = Subtotaal * 0.21m;
        Eindtotaal = Subtotaal + Btw;
    }
}