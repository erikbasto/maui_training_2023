using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTraining.DataAccess;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model to store sales to SQLite context.
/// </summary>
public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly IConnectivity _connectivity;
    private readonly ShopOutDbContext _outDbContext;

    [ObservableProperty]
    private ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

    [ObservableProperty]
    private int clientId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product selectedProduct;

    [ObservableProperty]
    private int quantity;

    public ICommand AddCommand { get; set; }

    public HelpSupportDetailViewModel(IConnectivity connectivity, ShopOutDbContext shopOutDbContext)
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        AddCommand = new Command(() =>
        {
            var sale = new Sale(
                ClientId,
                SelectedProduct.Id,
                Quantity,
                SelectedProduct.Name,
                SelectedProduct.Price,
                Quantity * SelectedProduct.Price);
            Sales.Add(sale);
        },
        () => true
        );
        _connectivity = connectivity;
        _outDbContext = shopOutDbContext;
        _connectivity.ConnectivityChanged += _connectivity_ConnectivityChanged;
    }

    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task SaveSale()
    {
        _outDbContext.Database.EnsureCreated();
        foreach (var item in Sales)
        {
            _outDbContext.Sales.Add(new SaleItem(
                item.ClientId,
                item.ProductId,
                item.Quantity,
                item.ProductPrice
                ));
        }

        await _outDbContext.SaveChangesAsync();
        await Shell.Current.DisplayAlert("Congrats", "Your purchases were successfully stored.", "OK");
    }

    private void _connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        SaveSaleCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection()
    {
        return _connectivity.NetworkAccess == NetworkAccess.Internet;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClientId = clientId;
    }

    [RelayCommand]
    private void DeletePurchase(Sale sale)
    {
        Sales.Remove(sale);
    }

}

