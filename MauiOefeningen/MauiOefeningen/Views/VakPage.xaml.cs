using MauiOefeningen.ViewModels;

namespace MauiOefeningen.Views;
public partial class VakPage : ContentPage
{
	public VakPage(VakViewModel viewModel)
	{
		this.InitializeComponent();
		this.BindingContext = viewModel;
	}
}