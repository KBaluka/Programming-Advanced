using MauiOefeningen.Views;

namespace MauiOefeningen;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(PersonenTonenPage), typeof(PersonenTonenPage));
    }
}