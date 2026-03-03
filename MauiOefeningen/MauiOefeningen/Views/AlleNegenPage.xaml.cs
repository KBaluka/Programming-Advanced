using MauiOefeningen.ViewModels;
namespace MauiOefeningen.Views;
public partial class AlleNegenPage : ContentPage
{
    public AlleNegenPage(AlleNegenViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}