using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class BuildingListPage : ContentPage
{
	public BuildingListPage(BuildingListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
