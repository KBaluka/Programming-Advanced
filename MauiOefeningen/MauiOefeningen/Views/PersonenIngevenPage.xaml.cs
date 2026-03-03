using MauiOefeningen.ViewModels;

namespace MauiOefeningen.Views;

public partial class PersonenIngevenPage : ContentPage
{
    public PersonenIngevenPage(PersonenIngevenViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}