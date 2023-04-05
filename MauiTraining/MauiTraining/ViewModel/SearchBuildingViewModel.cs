using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTraining.Models.Backend.Building;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for property searches
/// </summary>
public partial class SearchBuildingViewModel : ViewModelGlobal
{
    private readonly BuildingService _buildingService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    ObservableCollection<BuildingResponse> buildings;

    [ObservableProperty]
    BuildingResponse selectedBuilding;

    [ObservableProperty]
    string searchText;

    public SearchBuildingViewModel(BuildingService buildingService, INavigationService navigationService)
    {
        _navigationService = navigationService;
        _buildingService = buildingService;

        PropertyChanged += SearchBuildingViewModel_PropertyChanged;
    }

    private async void SearchBuildingViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedBuilding))
        {
            var uri = $"{nameof(BuildingDetailPage)}?id={SelectedBuilding.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }

    [RelayCommand]
    async Task GetBackEvent()
    {
        await _navigationService.GoToAsync("..");
    }

    public ICommand PerformSearch => new Command(async () =>
    {
        var buildingList = await _buildingService.SearchBuildings(SearchText);
        Buildings = new ObservableCollection<BuildingResponse>(buildingList);
    });
}

