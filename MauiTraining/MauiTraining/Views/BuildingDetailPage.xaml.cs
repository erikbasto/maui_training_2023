using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class BuildingDetailPage : ContentPage
{
	public BuildingDetailPage(BuildingDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
