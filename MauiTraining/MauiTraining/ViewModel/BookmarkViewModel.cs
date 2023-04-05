using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiTraining.Models.Backend.Building;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for bookmarks page.
/// It will load the list of user bookmarks from the service and handle the selection of the bookmarks.
/// Arrow function is used for command instead of RelayCommand decorator as an example.
/// </summary>
public partial class BookmarkViewModel : ViewModelGlobal
{
    private readonly INavigationService _navigationService;
    private readonly BuildingService _buildingService;

    [ObservableProperty]
    ObservableCollection<BuildingResponse> buildings;

    [ObservableProperty]
    private BuildingResponse selectedBuilding;

    public Command GetBuildingsCommand { get; }

    public BookmarkViewModel(INavigationService navigationService, BuildingService buildingService)
    {
        _navigationService = navigationService;
        _buildingService = buildingService;

        GetBuildingsCommand = new Command(async () => await LoadDataAsync());
        PropertyChanged += BookmarkViewModel_PropertyChanged;
    }

    private async void BookmarkViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedBuilding))
        {
            var uri = $"{nameof(BuildingDetailPage)}?id={SelectedBuilding.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }

    private async Task LoadDataAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var buildingList = await _buildingService.GetBookmarks();
            Buildings = new ObservableCollection<BuildingResponse>(buildingList);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}

