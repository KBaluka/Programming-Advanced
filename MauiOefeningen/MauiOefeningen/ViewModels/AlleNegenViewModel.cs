using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;
namespace MauiOefeningen.ViewModels;
public partial class AlleNegenViewModel : ObservableObject
{
    public partial class GetalTile : ObservableObject
    {
        public int Nummer { get; }
        [ObservableProperty] 
        bool beschikbaar, isEnabled;
        public string Tekst => Nummer.ToString();

        public GetalTile(int nummer)
        {
            Nummer = nummer;
            Beschikbaar = true;
            IsEnabled = false;
        }
    }
    readonly Random rnd = new();
    public ObservableCollection<GetalTile> Getallen { get; } = new();

    [ObservableProperty] 
    int dobbel1, dobbel2;
    [ObservableProperty] 
    bool gooiEnabled, herstartEnabled;
    [ObservableProperty] 
    string melding = "";

    int som;
    int restSom;
    int aantalKliks;
    bool spelBezig;
    bool gameOver;
    public AlleNegenViewModel()
    {
        Herstart();
    }
    [RelayCommand]
    void Herstart()
    {
        Getallen.Clear();
        for (int i = 1; i <= 9; i++)
            Getallen.Add(new GetalTile(i));

        dobbel1 = 0;
        dobbel2 = 0;
        melding = "";
        som = 0;
        restSom = 0;
        aantalKliks = 0;
        spelBezig = false;
        gameOver = false;
        GooiEnabled = true;
        HerstartEnabled = true;
        UpdateTilesEnabled();
        Gooi();
    }
    [RelayCommand]
    void Gooi()
    {
        if (gameOver) return;

        Dobbel1 = rnd.Next(1, 7);
        Dobbel2 = rnd.Next(1, 7);
        som = Dobbel1 + Dobbel2;
        restSom = som;
        aantalKliks = 0;
        spelBezig = true;
        GooiEnabled = false;
        melding = "";
        UpdateTilesEnabled();
        ControleTotaal();
    }
    [RelayCommand]
    async Task KiesGetal(int nummer)
    {
        if (gameOver) return;
        if (!spelBezig) return;
        var tile = Getallen.FirstOrDefault(t => t.Nummer == nummer);
        if (tile == null || !tile.Beschikbaar) return;
        if (aantalKliks >= 2)
        {
            await Shell.Current.DisplayAlert("Fout", "Je mag maximum 2 cijfers kiezen", "Ok");
            return;
        }
        if (aantalKliks == 0)
        {
            if (nummer == restSom)
            {
                Verwijder(tile);
                aantalKliks = 2;
                EindeBeurt();
                return;
            }
            if (BestaatPartnerVoor(nummer, restSom))
            {
                Verwijder(tile);
                restSom -= nummer;
                aantalKliks = 1;
                return;
            }
            await Shell.Current.DisplayAlert("Fout", "Dit getal kan je niet gebruiken", "Ok");
            return;
        }
        if (aantalKliks == 1)
        {
            if (nummer == restSom)
            {
                Verwijder(tile);
                aantalKliks = 2;
                EindeBeurt();
                return;
            }
            await Shell.Current.DisplayAlert("Fout", "Deze combinatie klopt niet", "Ok");
        }
    }
    void EindeBeurt()
    {
        spelBezig = false;
        GooiEnabled = true;
        UpdateTilesEnabled();
    }
    void Verwijder(GetalTile tile)
    {
        tile.Beschikbaar = false;
        tile.IsEnabled = false;
    }
    bool BestaatPartnerVoor(int eerste, int target)
    {
        foreach (var t in Getallen)
        {
            if (!t.Beschikbaar) continue;
            if (t.Nummer == eerste) continue;
            if (t.Nummer + eerste == target) return true;
        }
        return false;
    }
    void ControleTotaal()
    {
        var nums = Getallen.Where(t => t.Beschikbaar).Select(t => t.Nummer).ToList();
        bool mogelijk = nums.Any(n => n == som);
        if (!mogelijk)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] + nums[j] == som)
                    {
                        mogelijk = true;
                        break;
                    }
                }
                if (mogelijk) break;
            }
        }
        if (!mogelijk)
        {
            gameOver = true;
            spelBezig = false;
            GooiEnabled = false;
            foreach (var t in Getallen)
                t.IsEnabled = false;
            int score = nums.Sum();
            Melding = $"Er is geen combinatie meer mogelijk. Je score is {score}";
        }
    }
    void UpdateTilesEnabled()
    {
        foreach (var t in Getallen)
            t.IsEnabled = (!gameOver) && spelBezig && t.Beschikbaar;
    }
}