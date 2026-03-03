using MauiOefeningen.ViewModels;
namespace MauiOefeningen.Views;

public partial class VragenLijstPage : ContentPage
{
    public VragenLijstPage(VragenLijstViewModel vm)
    {
        this.InitializeComponent();
        this.BindingContext = vm;
    }
}