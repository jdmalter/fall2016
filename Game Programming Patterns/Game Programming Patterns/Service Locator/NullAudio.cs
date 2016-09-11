namespace Game_Programming_Patterns.Service_Locator
{
    public class NullAudio : Audio
    {
        public void PlaySound(int soundId)
        {
            /* Do nothing. */
        }

        public void StopSound(int soundId)
        {
            /* Do nothing. */
        }

        public void StopAllSounds()
        {
            /* Do nothing. */
        }
    }
}
