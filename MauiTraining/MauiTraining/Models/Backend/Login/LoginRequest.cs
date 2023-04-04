namespace MauiTraining.Models.Backend.Login;

/// <summary>
/// Login request model.
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// User email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// User password.
    /// </summary>
    public string Password { get; set; }
}

