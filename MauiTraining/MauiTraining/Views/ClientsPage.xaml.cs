using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage(ClientsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
