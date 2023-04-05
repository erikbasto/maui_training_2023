using CommunityToolkit.Mvvm.ComponentModel;
using MauiTraining.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for product details page. It loads static data from InMemoryContext.
/// </summary>
public partial class ProductDetailsViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    decimal price;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        var context = new ShopDbContext();
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product != null)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }
    }
}

