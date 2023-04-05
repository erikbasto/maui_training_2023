using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class HelpSupportDetailPage : ContentPage
{
	public HelpSupportDetailPage(HelpSupportDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
