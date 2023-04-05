namespace MauiTraining.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var accessToken = Preferences.Get("accesstoken", string.Empty);
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
    }
}
