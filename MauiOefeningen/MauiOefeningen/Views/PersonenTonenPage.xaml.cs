using System.Collections.ObjectModel;
using MauiOefeningen.Models;

namespace MauiOefeningen.Views;
[QueryProperty(nameof(Data), "data")]
public partial class PersonenTonenPage : ContentPage
{
    public string Data
    {
        set
        {
            var personen = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<Persoon>>(Uri.UnescapeDataString(value));
            PersonenList.ItemsSource = personen;
            int aantal = personen.Count;
            int gem = BerekenGemiddeldeLeeftijd(personen);
            ResultaatLabel.Text = $"Het aantal personen is {aantal} en de gemiddelde leeftijd is {gem}";
        }
    }
    public PersonenTonenPage()
    {
        InitializeComponent();
    }
    int BerekenGemiddeldeLeeftijd(IEnumerable<Persoon> personen)
    {
        var list = personen.ToList();
        if (list.Count == 0) return 0;
        var leeftijden = list.Select(p =>
        {
            int age = DateTime.Today.Year - p.Geboortedatum.Year;
            if (p.Geboortedatum.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        });
        return (int)Math.Round(leeftijden.Average());
    }
}