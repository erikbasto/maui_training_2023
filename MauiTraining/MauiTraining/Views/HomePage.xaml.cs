﻿using MauiTraining.ViewModel;

namespace MauiTraining.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
