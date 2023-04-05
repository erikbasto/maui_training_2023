using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class SearchBuildingPage : ContentPage
{
	public SearchBuildingPage(SearchBuildingViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
