using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTraining.Models.Backend.Building;
using MauiTraining.Services;

namespace MauiTraining.ViewModel;

/// <summary>
/// View model for the property details.
/// It includes a query attributable to receive the property id.
/// It includes the bookmark processing and commands to call/text to the owner.
/// </summary>
public partial class BuildingDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly BuildingService _buildingService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private BuildingResponse building;

    [ObservableProperty]
    private string imageSource;

    public BuildingDetailViewModel(BuildingService buildingService, INavigationService navigationService)
    {
        _navigationService = navigationService;
        _buildingService = buildingService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        await LoadDataAsync(id);
    }

    public async Task LoadDataAsync(int buildingId)
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            Building = await _buildingService.GetBuildingById(buildingId);
            ImageSource = Building.IsBookmarkEnabled ? "bookmark_fill_icon" : "bookmark_empty_icon";
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GetBackEvent()
    {
        await _navigationService.GoToAsync("..");
    }

    [RelayCommand]
    async Task SaveBookmark()
    {
        var bookmark = new BookmarkRequest
        {
            BuildingId = Building.Id,
            UserId = Preferences.Get("userId", string.Empty)
        };

        await _buildingService.SaveBookmark(bookmark);
        await LoadDataAsync(Building.Id);

    }

    [RelayCommand]
    async Task CallOwner()
    {
        var confirm = Application.Current.MainPage.DisplayAlert(
            "Call the owner",
            $"Do you want to call to: {Building.Phone}?",
            "Yes",
            "No");
        if (await confirm)
        {
            try
            {
                PhoneDialer.Open(Building.Phone);
            }
            catch (ArgumentNullException)
            {
                await Application.Current.MainPage.DisplayAlert("Can't make this call", "The phone number is invalid", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                await Application.Current.MainPage.DisplayAlert("Can't make this call", "The device cannot make phone calls", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Call error", ex.Message, "OK");
            }

        }
    }

    [RelayCommand]
    async Task TextMessageOwner()
    {
        var message = new SmsMessage("Hi, can you please send me information about the property?", Building.Phone);
        var confirmar = Application.Current.MainPage.DisplayAlert("Send message",
            $"Do you want to send a message to {Building.Phone}?",
            "Yes",
            "No");
        if (await confirmar)
        {
            try
            {
                await Sms.ComposeAsync(message);
            }
            catch (ArgumentNullException)
            {
                await Application.Current.MainPage.DisplayAlert("Can't be sent", "The phone number is invalid", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                await Application.Current.MainPage.DisplayAlert("Can't be sent", "The device cannot send SMS", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("SMS error", ex.Message, "OK");
            }

        }
    }
}

