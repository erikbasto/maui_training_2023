using System.Text;
using MauiTraining.Models.Backend.Login;
using MauiTraining.Models.Config;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MauiTraining.Services;

/// <summary>
/// Security service used for login.
/// </summary>
public class SecurityService
{
    private HttpClient client;
    private Settings settings;

    public SecurityService(HttpClient client, IConfiguration configuration)
    {
        this.client = client;
        settings = configuration.GetRequiredSection(nameof(Settings)).Get<Settings>();
    }

    /// <summary>
    /// Consumes the login service.
    /// If its a valid user, user information is added on Preferences.
    /// </summary>
    /// <param name="email">User email.</param>
    /// <param name="password">User password.</param>
    /// <returns>True if login successfully. False otherwise. </returns>
    public async Task<bool> Login(string email, string password)
    {
        var url = $"{settings.UrlBase}/api/usuario/login";
        var loginRequest = new LoginRequest
        {
            Email = email,
            Password = password
        };

        var json = JsonConvert.SerializeObject(loginRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
            return false;

        var jsonResultado = await response.Content.ReadAsStringAsync();
        var resultado = JsonConvert.DeserializeObject<UserResponse>(jsonResultado);

        Preferences.Set("accesstoken", resultado.Token);
        Preferences.Set("userId", resultado.Id);
        Preferences.Set("email", resultado.Email);
        Preferences.Set("fullname", $"{resultado.Name} {resultado.Lastname}");
        Preferences.Set("phone", resultado.Phone);
        Preferences.Set("username", resultado.UserName);

        return true;
    }
}

