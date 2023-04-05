using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiTraining.Models.Backend.Building;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for building lists by category.
/// Category id is provided as parameter. 
/// </summary>
public partial class BuildingListViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly INavigationService _navigationService;
    private readonly BuildingService _buildingService;

    [ObservableProperty]
    ObservableCollection<BuildingResponse> buildings;

    [ObservableProperty]
    BuildingResponse selectedBuilding;

    public BuildingListViewModel(INavigationService navigationService, BuildingService buildingService)
    {
        _buildingService = buildingService;
        _navigationService = navigationService;
        PropertyChanged += BuildingListViewModel_PropertyChanged;
    }

    private async void BuildingListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedBuilding))
        {
            var uri = $"{nameof(BuildingDetailPage)}?id={SelectedBuilding.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        await LoadDataAsync(id);

    }

    public async Task LoadDataAsync(int categoryId)
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var buildingList = await _buildingService.GetBuildingsByCategory(categoryId);
            Buildings = new ObservableCollection<BuildingResponse>(buildingList);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

}

