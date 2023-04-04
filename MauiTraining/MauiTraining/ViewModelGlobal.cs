using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiTraining;

/// <summary>
/// ViewModel base class to add a busy flag for services.
/// </summary>
public partial class ViewModelGlobal : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !IsBusy;
}

