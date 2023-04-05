namespace MauiTraining.Services;

/// <inheritdoc/>
public class DatabasePathService : IDatabasePathService
{
    /// <inheritdoc/>
    public string Get(string filename)
    {
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(folderPath, filename);
    }
}

