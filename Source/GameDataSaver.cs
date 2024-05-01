using System;
using System.Threading.Tasks;

namespace StorageSystem
{
    /// <summary>
    /// Manages the saving and loading of game data using specified strategies.
    /// </summary>
    /// <typeparam name="T">Type of the data to manage.</typeparam>
    public class GameDataSaver<T> where T : class
    {
        private ISaveState<T> m_CurrentState;
        private readonly DataCache<T> m_DataCache;

        public GameDataSaver(ISaveState<T> initialState)
        {
            m_CurrentState = initialState;
            m_DataCache = new DataCache<T>();
        }

        /// <summary>
        /// Asynchronously saves game data using the current save strategy.
        /// </summary>
        /// <param name="data">Data to be saved.</param>
        public async Task SaveGameDataAsync(T data)
        {
            try
            {
                await m_CurrentState.SaveAsync(this, data);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error saving game data: {ex.Message}");
                throw new DataSaveException("Error saving game data");
            }
        }

        /// <summary>
        /// Asynchronously loads game data using the current load strategy.
        /// </summary>
        public async Task<T> LoadGameDataAsync()
        {
            try
            {
                return await m_DataCache.GetDataAsync(async () =>
                {
                    var loadedData = await m_CurrentState.LoadAsync(this);
                    if (loadedData == null)
                    {
                        throw new DataLoadException("Failed to load game data");
                    }
                    return loadedData;
                });
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error loading game data: {ex.Message}");
                throw new DataLoadException("Error loading game data");
            }
        }

        /// <summary>
        /// Sets a new save/load strategy for managing game data.
        /// </summary>
        /// <param name="newState">The new save/load strategy to be used.</param>
        public void SetSaveStrategy(ISaveState<T> newState)
        {
            m_CurrentState = newState;
            m_DataCache.InvalidateCache();
        }
    }
}