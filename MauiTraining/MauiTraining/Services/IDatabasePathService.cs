namespace MauiTraining.Services
{
    /// <summary>
    /// Interface to define the database path used for sqllite.
    /// This is implemented by device.
    /// </summary>
    public interface IDatabasePathService
	{
		/// <summary>
		/// Return the sqlite path using the filename provided as parameter.
		/// </summary>
		/// <param name="filename">Db filename.</param>
		/// <returns>Db path.</returns>
        string Get(string filename);
    }
}

