using System.Threading.Tasks;

namespace StorageSystem
{
    /// <summary>
    /// Interface for save state strategies.
    /// </summary>
    /// <typeparam name="T">Type of data to be saved or loaded.</typeparam>
    public interface ISaveState<T> where T : class
    {
        /// <summary>
        /// Asynchronously saves data to a persistent storage.
        /// </summary>
        /// <param name="context">The game data saver context.</param>
        /// <param name="data">Data to be saved.</param>
        Task SaveAsync(GameDataSaver<T> context, T data);

        /// <summary>
        /// Asynchronously loads data from a persistent storage.
        /// </summary>
        /// <param name="context">The game data saver context.</param>
        Task<T> LoadAsync(GameDataSaver<T> context);
    }
}