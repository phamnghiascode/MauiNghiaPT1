using ClothFashion.ViewModels;

namespace ClothFashion.Views;

public partial class WelcomeView : ContentPage
{
	public WelcomeView(WelcomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}