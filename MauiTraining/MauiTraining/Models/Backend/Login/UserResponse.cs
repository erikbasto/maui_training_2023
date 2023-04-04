using Newtonsoft.Json;

namespace MauiTraining.Models.Backend.Login
{
    /// <summary>
    /// User response model.
    /// </summary>
	public class UserResponse
	{
        /// <summary>
        /// User id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty("nombre")]
        public string Name { get; set; }

        /// <summary>
        /// Access token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User phone.
        /// </summary>
        [JsonProperty("telefono")]
        public string Phone { get; set; }
    }
}

