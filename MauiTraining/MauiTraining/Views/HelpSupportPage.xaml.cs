using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage(HelpSupportViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
