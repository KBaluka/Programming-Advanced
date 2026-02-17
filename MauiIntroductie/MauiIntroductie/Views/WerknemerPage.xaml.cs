namespace MauiIntroductie.Views;

public partial class WerknemerPage : ContentPage
{
	public WerknemerPage(WerknemerViewModel viewModel)
	{
		this.InitializeComponent();
		this.BindingContext = viewModel;
	}
}