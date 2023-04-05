using CommunityToolkit.Mvvm.Input;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for settings page with logout option.
/// </summary>
public partial class SettingsViewModel : ViewModelGlobal
{
    private readonly INavigationService _navigationService;

    [RelayCommand]
    async Task Logout()
    {
        Preferences.Set("accesstoken", string.Empty);
        var uri = $"//{nameof(AboutPage)}";

        await _navigationService.GoToAsync(uri);
    }

    public SettingsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
}

