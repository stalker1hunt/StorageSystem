using System.Threading.Tasks;
using StorageSystem.States;
using UnityEngine;

namespace StorageSystem.Example
{
    public class GameSettingsManager
    {
        public async Task ExampleUsageAsync()
        {
            var options = new GameOptions(0.5f, 50, true);

            // Initialize the saver with the JSON storage strategy
            var saver = new GameDataSaver<GameOptions>(new JsonSaveState<GameOptions>());

            // Save and load settings using JSON
            await saver.SaveGameDataAsync(options);
            var loadedOptions = await saver.LoadGameDataAsync();
            Debug.Log("Loaded JSON: Sound Volume " + loadedOptions?.SoundVolume);

            // Switch to PlayerPrefs strategy
            saver.SetSaveStrategy(new PlayerPrefsSaveState<GameOptions>());
            await saver.SaveGameDataAsync(options);
            loadedOptions = await saver.LoadGameDataAsync();
            Debug.Log("Loaded PlayerPrefs: Brightness " + loadedOptions?.Brightness);

            // Switch to Base64 strategy
            saver.SetSaveStrategy(new Base64SaveState<GameOptions>());
            await saver.SaveGameDataAsync(options);
            loadedOptions = await saver.LoadGameDataAsync();
            Debug.Log("Loaded Base64: Fullscreen " + loadedOptions?.Fullscreen);
        }
    }
}