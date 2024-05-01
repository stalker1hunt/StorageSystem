using System.Threading.Tasks;
using UnityEngine;

namespace StorageSystem.States
{
    /// <summary>
    /// Implements PlayerPrefs save strategy, stores data in PlayerPrefs format.
    /// </summary>
    /// <typeparam name="T">Type of the data to be saved or loaded.</typeparam>
    public class PlayerPrefsSaveState<T> : ISaveState<T> where T : class
    {
        private string PlayerPrefsKey { get; set; } = "gameOptions";

        public async Task SaveAsync(GameDataSaver<T> context, T data)
        {
            string jsonData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(PlayerPrefsKey, jsonData);
            PlayerPrefs.Save();
            await Task.CompletedTask;
        }

        public Task<T> LoadAsync(GameDataSaver<T> context)
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                return Task.FromResult<T>(null);
            }

            string jsonData = PlayerPrefs.GetString(PlayerPrefsKey);
            return Task.FromResult(JsonUtility.FromJson<T>(jsonData));
        }
    }
}