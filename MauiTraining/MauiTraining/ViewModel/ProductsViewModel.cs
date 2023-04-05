using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTraining.DataAccess;
using MauiTraining.Services;
using MauiTraining.Views;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model to load the product list from InMemoryContext.
/// </summary>
public partial class ProductsViewModel : ViewModelGlobal
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    ObservableCollection<Product> products;

    [ObservableProperty]
    Product selectedProduct;

    [ObservableProperty]
    bool isRefreshing;

    public ProductsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        LoadProductList();

        PropertyChanged += ProductsViewModel_PropertyChanged;
    }

    private async void ProductsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedProduct))
        {
            var uri = $"{nameof(ProductDetailsPage)}?id={SelectedProduct.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }

    private void LoadProductList()
    {
        var context = new ShopDbContext();
        Products = new ObservableCollection<Product>(context.Products);
        context.Dispose();
    }

    [RelayCommand]
    private async void Refresh()
    {
        LoadProductList();
        await Task.Delay(3000); // add only to display the activityindicator.
        IsRefreshing = false;
    }
}

