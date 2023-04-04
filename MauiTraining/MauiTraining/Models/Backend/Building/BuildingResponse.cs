using Newtonsoft.Json;

namespace MauiTraining.Models.Backend.Building
{
    /// <summary>
    /// Model for properties.
    /// </summary>
	public class BuildingResponse
	{
        /// <summary>
        /// Property id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property name or title.
        /// </summary>
        [JsonProperty("nombre")]
        public string Name { get; set; }

        /// <summary>
        /// Property address
        /// </summary>
        [JsonProperty("direccion")]
        public string Address { get; set; }

        /// <summary>
        /// Property description
        /// </summary>
        [JsonProperty("detalle")]
        public string Description { get; set; }

        /// <summary>
        /// Property image.
        /// </summary>
        [JsonProperty("imagenUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Property price.
        /// </summary>
        [JsonProperty("precio")]
        public decimal Price { get; set; }

        /// <summary>
        /// Owner id.
        /// </summary>
        [JsonProperty("usuarioId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Defines if is a trending property.
        /// </summary>
        public bool IsTrending { get; set; }

        /// <summary>
        /// Defines if bookmark option is enabled.
        /// </summary>
        public bool IsBookmarkEnabled { get; set; }

        /// <summary>
        /// Bookmark user id.
        /// </summary>
        public string BookmarkUserId { get; set; }

        /// <summary>
        /// Phone.
        /// </summary>
        [JsonProperty("telefono")]
        public string Phone { get; set; }
    }
}

