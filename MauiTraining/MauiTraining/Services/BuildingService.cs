using System.Net.Http.Headers;
using System.Text;
using MauiTraining.Models.Backend.Building;
using MauiTraining.Models.Config;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MauiTraining.Services;

/// <summary>
/// Building service used by Properties pages.
/// </summary>
public class BuildingService
{
    private readonly HttpClient client;
    private Settings settings;

    public BuildingService(HttpClient client, IConfiguration configuration)
    {
        this.client = client;
        this.settings = configuration.GetRequiredSection(nameof(Settings)).Get<Settings>();
    }

    /// <summary>
    /// Get property categories.
    /// </summary>
    /// <returns>List of categories.</returns>
    public async Task<List<CategoryResponse>> GetCategories()
    {
        var uri = $"{settings.UrlBase}/api/category";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var response = await client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<List<CategoryResponse>>(response);
    }

    /// <summary>
    /// Get a list of properties by category.
    /// </summary>
    /// <param name="categoryId">Category id.</param>
    /// <returns>List of properties.</returns>
    public async Task<List<BuildingResponse>> GetBuildingsByCategory(int categoryId)
    {
        var uri = $"{settings.UrlBase}/api/inmueble/category/{categoryId}";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var response = await client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<List<BuildingResponse>>(response);
    }

    /// <summary>
    /// Get favorite properties.
    /// </summary>
    /// <returns>List of favorite properties.</returns>
    public async Task<List<BuildingResponse>> GetFavoriteBuildings()
    {
        var uri = $"{settings.UrlBase}/api/inmueble/trending";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var response = await client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<List<BuildingResponse>>(response);
    }

    /// <summary>
    /// Get a property by Id.
    /// </summary>
    /// <param name="buildingId">Property id.</param>
    /// <returns>Property.</returns>
    public async Task<BuildingResponse> GetBuildingById(int buildingId)
    {
        var uri = $"{settings.UrlBase}/api/inmueble/{buildingId}";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var response = await client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<BuildingResponse>(response);
    }

    /// <summary>
    /// Bookmark a property.
    /// </summary>
    /// <param name="bookmarkRequest">Bookmark request.</param>
    /// <returns>True if it was saved. False otherwise.</returns>
    public async Task<bool> SaveBookmark(BookmarkRequest bookmarkRequest)
    {
        var url = $"{settings.UrlBase}/api/bookmark";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var json = JsonConvert.SerializeObject(bookmarkRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        return response.IsSuccessStatusCode;
    }

    /// <summary>
    /// Get a list of bookmarks from the user.
    /// </summary>
    /// <returns>Properties with bookmark = true.</returns>
    public async Task<List<BuildingResponse>> GetBookmarks()
    {
        var uri = $"{settings.UrlBase}/api/inmueble/bookmark";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var response = await client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<List<BuildingResponse>>(response);
    }

    /// <summary>
    /// Search a property using a string value.
    /// </summary>
    /// <param name="buildingValue">Search text.</param>
    /// <returns>List of properties matching with the search value.</returns>
    public async Task<List<BuildingResponse>> SearchBuildings(string buildingValue)
    {
        var uri = $"{settings.UrlBase}/api/inmueble/search/{buildingValue}";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var response = await client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<List<BuildingResponse>>(response);
    }
}

