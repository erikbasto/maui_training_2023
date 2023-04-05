using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
