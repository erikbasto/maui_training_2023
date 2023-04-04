using Newtonsoft.Json;

namespace MauiTraining.Models.Backend.Building;

/// <summary>
/// Model for property category.
/// </summary>
public class CategoryResponse
{
    /// <summary>
    /// Category id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Category name.
    /// </summary>
    [JsonProperty("nombre")]
    public string Name { get; set; }

    /// <summary>
    /// Category image
    /// </summary>
    public string ImageUrl { get; set; }
}

