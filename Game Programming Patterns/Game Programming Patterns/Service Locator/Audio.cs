namespace Game_Programming_Patterns.Service_Locator
{
    public interface Audio
    {
        void PlaySound(int soundId);

        void StopSound(int soundId);

        void StopAllSounds();
    }
}
