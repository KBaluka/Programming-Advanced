namespace MauiIntroductie.Views;

public partial class FotoPage : ContentPage
{
	public FotoPage(FotoViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}