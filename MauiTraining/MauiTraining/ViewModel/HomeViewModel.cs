using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTraining.Models.Backend.Building;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for Properties home page. Includes redirects to search and properties list.
/// </summary>
public partial class HomeViewModel : ViewModelGlobal
{
    private readonly BuildingService _buildingService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    string userName;

    [ObservableProperty]
    CategoryResponse selectedCategory;

    [ObservableProperty]
    ObservableCollection<CategoryResponse> categories;

    [ObservableProperty]
    ObservableCollection<BuildingResponse> favoriteBuildings;

    public Command GetDataCommand { get; }

    public HomeViewModel(BuildingService buildingService, INavigationService navigationService)
    {
        _buildingService = buildingService;
        _navigationService = navigationService;
        UserName = Preferences.Get("name", string.Empty);
        GetDataCommand = new Command(async () => await LoadDataAsync());
        GetDataCommand.Execute(this);
    }

    public async Task LoadDataAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            var listCategories = await _buildingService.GetCategories();
            Categories = new ObservableCollection<CategoryResponse>(listCategories);

            var listFavs = await _buildingService.GetFavoriteBuildings();
            FavoriteBuildings = new ObservableCollection<BuildingResponse>(listFavs);

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

    [RelayCommand]
    private async Task CategoryEventSelected()
    {
        var uri = $"{nameof(BuildingListPage)}?id={SelectedCategory.Id}";
        await _navigationService.GoToAsync(uri);
    }

    [RelayCommand]
    private async Task SearchBuildings()
    {
        var uri = $"{nameof(SearchBuildingPage)}";
        await _navigationService.GoToAsync(uri);
    }
}

