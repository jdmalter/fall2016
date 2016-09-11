namespace Game_Programming_Patterns.Service_Locator
{
    public class LoggedAudio : Audio
    {
        private Audio _wrapped;

        public LoggedAudio(Audio wrapped)
        {
            _wrapped = wrapped;
        }

        public void PlaySound(int soundId)
        {
            Log("play sound");
            _wrapped.PlaySound(soundId);
        }

        public void StopSound(int soundId)
        {
            Log("stop sound");
            _wrapped.StopSound(soundId);
        }

        public void StopAllSounds()
        {
            Log("stop all sounds");
            _wrapped.StopAllSounds();
        }

        private void Log(string message)
        {
            // Code to log message...
        }
    }
}
