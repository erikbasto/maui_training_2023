using System.ComponentModel;
using MauiTraining.DataAccess;

namespace MauiTraining.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();

        var context = new ShopDbContext();
        foreach (var category in context.Categories)
        {
            container.Children.Add(new Label { Text = category.Name });
        }
    }
}
