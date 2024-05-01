using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSystem.States
{
    /// <summary>
    /// Implements JSON save strategy, stores data in JSON format in files.
    /// </summary>
    /// <typeparam name="T">Type of the data to be saved or loaded.</typeparam>
    public class JsonSaveState<T> : ISaveState<T> where T : class, new()
    {
        private string FilePath { get; set; } = "gameOptions.json";

        public async Task SaveAsync(GameDataSaver<T> context, T data)
        {
            string jsonData = JsonUtility.ToJson(data);
            await File.WriteAllTextAsync(FilePath, jsonData);
        }

        public async Task<T> LoadAsync(GameDataSaver<T> context)
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }
            string jsonData = await File.ReadAllTextAsync(FilePath);
            var data = JsonUtility.FromJson<T>(jsonData);
            if (data == null)
            {
                data = new T();
                await SaveAsync(context, data);
            }
            return data;
        }
    }

}