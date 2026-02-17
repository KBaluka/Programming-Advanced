namespace MauiIntroductie.Views;

public partial class NamenPage : ContentPage
{
	public NamenPage(NamenViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}