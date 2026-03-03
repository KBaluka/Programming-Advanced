namespace MauiIntroductie.Views;

public partial class WerknemerDetailPage : ContentPage
{
	public WerknemerDetailPage(WerknemerDetailViewModel viewModel)
	{
		this.InitializeComponent();
		this.BindingContext = viewModel;
	}
}