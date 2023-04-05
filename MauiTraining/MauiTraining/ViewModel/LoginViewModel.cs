using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTraining.Services;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for login page.
/// It includes the command logic for login and validations tied to Internet connectivity.
/// </summary>
public partial class LoginViewModel : ViewModelGlobal
{
    private readonly IConnectivity _conectivity;
    private readonly SecurityService _securityService;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    public LoginViewModel(IConnectivity connectivity, SecurityService securityService)
    {
        _conectivity = connectivity;
        _securityService = securityService;

        _conectivity.ConnectivityChanged += _conectivity_ConnectivityChanged;
    }

    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task LoginMethod()
    {
        var resultado = await _securityService.Login(Email, Password);
        if (resultado)
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await Shell.Current.DisplayAlert(
                "Important!",
                "The provided credentials are invalid. Please check and try again.",
                "OK");
        }
    }

    private void _conectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        LoginMethodCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection()
    {
        return _conectivity.NetworkAccess == NetworkAccess.Internet;
    }
}

