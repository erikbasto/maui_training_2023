using Newtonsoft.Json;

namespace MauiTraining.Models.Backend.Building;

/// <summary>
/// Model for the property bookmark.
/// </summary>
public class BookmarkRequest
{
    /// <summary>
    /// User id.
    /// </summary>
    [JsonProperty("usuarioId")]
    public string UserId { get; set; }

    /// <summary>
    /// Property id
    /// </summary>
    [JsonProperty("inmuebleId")]
    public int BuildingId { get; set; }
}

