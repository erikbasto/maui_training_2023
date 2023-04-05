namespace MauiTraining.Services;

/// <summary>
/// Navigation service to redirect between pages.
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Route to the uri.
    /// </summary>
    /// <param name="uri">Page uri.</param>
    /// <returns>Async task.</returns>
    Task GoToAsync(string uri);

    /// <summary>
    /// Route to the uri using the parameters provided as dictionary.
    /// </summary>
    /// <param name="uri">Page uri.</param>
    /// <param name="parameters">Page parameters.</param>
    /// <returns>Async task.</returns>
    Task GoToAsync(string uri, IDictionary<string, object> parameters);
}

