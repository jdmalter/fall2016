using System;

namespace Game_Programming_Patterns.Update_Method
{
    public class Statue : Entity
    {
        private int _frames = 0;
        private int _delay;

        public Statue(int delay)
        {
            _delay = delay;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public void Update()
        {
            if (++_frames == _delay)
            {
                ShootLightnig();

                // Reset the timer.
                _frames = 0;
            }
        }

        private void ShootLightnig()
        {
            // Shoot the lightnig...
        }
    }
}
