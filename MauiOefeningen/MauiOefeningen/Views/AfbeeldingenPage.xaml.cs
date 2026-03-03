using MauiOefeningen.ViewModels;

namespace MauiOefeningen.Views;

public partial class AfbeeldingenPage : ContentPage
{
	public AfbeeldingenPage(AfbeeldingenViewModel viewModel)
	{
		this.InitializeComponent();
		this.BindingContext = viewModel;
	}
}