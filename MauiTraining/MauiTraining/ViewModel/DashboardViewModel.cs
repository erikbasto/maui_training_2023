using CommunityToolkit.Mvvm.ComponentModel;
using MauiTraining.DataAccess;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for dashboard.
/// </summary>
public partial class DashboardViewModel : ViewModelGlobal
{
    [ObservableProperty]
    int visits;

    [ObservableProperty]
    int clients;

    [ObservableProperty]
    decimal total;

    [ObservableProperty]
    int totalProducts;

    public DashboardViewModel(ShopOutDbContext shopOutDbContext)
    {
        var db = new ShopDbContext();

        shopOutDbContext.Database.EnsureCreated();
        Visits = shopOutDbContext
            .Sales
            .ToList()
            .DistinctBy(s => s.ClientId)
            .ToList()
            .Count();
        Clients = db.Clients.Count();
        Total = shopOutDbContext
            .Sales
            .ToList()
            .Sum(s => s.Quantity * s.Precio);
        TotalProducts = shopOutDbContext
            .Sales
            .ToList()
            .Sum(s => s.Quantity);
    }
}

