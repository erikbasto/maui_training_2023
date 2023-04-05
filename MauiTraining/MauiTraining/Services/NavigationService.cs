namespace MauiTraining.Services;

/// <inheritdoc/>
public class NavigationService : INavigationService
{
    /// <inheritdoc/>
		public Task GoToAsync(string uri)
    {
        return Shell.Current.GoToAsync(uri);
    }

    /// <inheritdoc/>
    public Task GoToAsync(string uri, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(uri, parameters);
    }
}

