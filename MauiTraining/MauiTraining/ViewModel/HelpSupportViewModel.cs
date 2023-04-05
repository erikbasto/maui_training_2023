using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiTraining.DataAccess;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for sales main page.
/// </summary>
public partial class HelpSupportViewModel : ViewModelGlobal
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client selectedClient;

    public HelpSupportViewModel(INavigationService navigationService)
    {
        var context = new ShopDbContext();
        Clients = new ObservableCollection<Client>(context.Clients);

        PropertyChanged += HelpSupportData_PropertyChanged;
        _navigationService = navigationService;
    }

    private async void HelpSupportData_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (SelectedClient != null)
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={SelectedClient.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }
}

