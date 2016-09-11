namespace Game_Programming_Patterns.Service_Locator
{
    public static class Locator
    {
        private static Audio _service;
        private static NullAudio _nullService;

        public static Audio Service
        {
            get
            {
                return _service;
            }
            set
            {
                _service = value == null ? _nullService : value;
            }
        }

        public static void Initialize()
        {
            _service = _nullService;
        }
    }
}
