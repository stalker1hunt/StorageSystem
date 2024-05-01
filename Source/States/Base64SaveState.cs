using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSystem.States
{
    /// <summary>
    /// Implements Base64 save strategy, stores data in Base64 format in files.
    /// </summary>
    /// <typeparam name="T">Type of the data to be saved or loaded.</typeparam>
    public class Base64SaveState<T> : ISaveState<T> where T : class
    {
        private string FilePath { get; set; } = "gameOptions.b64";

        public async Task SaveAsync(GameDataSaver<T> context, T data)
        {
            string jsonData = JsonUtility.ToJson(data);
            string base64Data = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonData));
            await File.WriteAllTextAsync(FilePath, base64Data);
        }

        public async Task<T> LoadAsync(GameDataSaver<T> context)
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }

            string base64Data = await File.ReadAllTextAsync(FilePath);
            string jsonData = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64Data));
            return JsonUtility.FromJson<T>(jsonData);
        }
    }
}