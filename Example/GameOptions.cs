namespace StorageSystem.Example
{
    public class GameOptions
    {
        public readonly float SoundVolume;
        public readonly int Brightness;
        public readonly bool Fullscreen;

        public GameOptions(float soundVolume, int brightness, bool fullscreen)
        {
            SoundVolume = soundVolume;
            Brightness = brightness;
            Fullscreen = fullscreen;
        }

        public GameOptions()
        {
            SoundVolume = 1;
            Brightness = 50;
            Fullscreen = false;
        }
    }
}