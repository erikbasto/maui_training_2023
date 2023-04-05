using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class BookmarkPage : ContentPage
{
    private BookmarkViewModel _viewModel;

    public BookmarkPage(BookmarkViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    /// <summary>
    /// Refresh the list as soon as the page is displayed.
    /// </summary>
    protected override void OnAppearing()
    {
        _viewModel.GetBuildingsCommand.Execute(this);
    }
}
