using System;

namespace Game_Programming_Patterns.Event_Queue
{
    public class Audio
    {
        private static readonly int MAX_PENDING = 16;
        private static readonly PlayMessage[] PENDING = new PlayMessage[MAX_PENDING];

        private static int _head = 0;
        private static int _tail = 0;

        public static void init()
        {
            _head = 0;
            _tail = 0;
        }

        public void PlaySound(int soundId, int volume)
        {
            // Walk the pending requests.
            for (int i = _head; i != _tail; i = (i + 1) % MAX_PENDING)
            {
                if (PENDING[i].soundId == soundId)
                {
                    // Use the larger of the two volumes.
                    PENDING[i].volume = Math.Max(volume, PENDING[i].volume);

                    // Don't need to enqueue.
                    return;
                }
            }
            if ((_tail + 1) % MAX_PENDING != _head)
            {
                PENDING[_tail].soundId = soundId;
                PENDING[_tail].volume = volume;
                _tail = (_tail + 1) % MAX_PENDING;
            }
        }

        public static void Update()
        {
            // If there are no pending requests, do nothing.
            if (_head == _tail) return;

            // Play the sound

            _head = (_head + 1) % MAX_PENDING;
        }
    }
}
