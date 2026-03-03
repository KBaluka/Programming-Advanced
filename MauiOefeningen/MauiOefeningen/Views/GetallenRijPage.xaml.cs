using MauiOefeningen.ViewModels;

namespace MauiOefeningen.Views;

public partial class GetallenRijPage : ContentPage
{
    public GetallenRijPage(GetallenRijViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}