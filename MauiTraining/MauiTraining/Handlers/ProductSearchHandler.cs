using System;
using MauiTraining.DataAccess;
using MauiTraining.Views;

namespace MauiTraining.Handlers;

/// <summary>
/// Product search handler for product page.
/// </summary>
public class ProductSearchHandler : SearchHandler
{
    private ShopDbContext dbContext;

    public ProductSearchHandler()
    {
        this.dbContext = new ShopDbContext();
    }

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
            return;
        }

        var results = dbContext.Products.Where(p => p.Name.ToLowerInvariant().Contains(newValue.ToLowerInvariant())).ToList();
        ItemsSource = results;
    }

    protected override async void OnItemSelected(object item)
    {
        var uri = $"{nameof(ProductDetailsPage)}?id={((Product)item).Id}";
        await Shell.Current.GoToAsync(uri);
    }
}

