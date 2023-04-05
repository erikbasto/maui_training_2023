using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiTraining.DataAccess;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for clients page to load info from InMemory context and display it in a CarrouselView.
/// </summary>
public partial class ClientsViewModel : ViewModelGlobal
{
    [ObservableProperty]
    ObservableCollection<Client> clients;

    [ObservableProperty]
    Client selectedClient;


    public ClientsViewModel()
    {
        var context = new ShopDbContext();
        Clients = new ObservableCollection<Client>(context.Clients);
    }
}

