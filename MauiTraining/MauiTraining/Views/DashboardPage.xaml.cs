using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
