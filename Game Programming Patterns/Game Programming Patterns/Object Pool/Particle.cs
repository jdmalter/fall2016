namespace Game_Programming_Patterns.Object_Pool
{
    public class Particle
    {
        private int _framesLeft = 0;
        private double _x, _y;
        private double _xVel, _yVel;

        public void Create(double x, double y, double xVel, double yVel, int lifetime)
        {
            _x = x;
            _y = y;
            _xVel = xVel;
            _yVel = yVel;
            _framesLeft = lifetime;
        }

        public bool Animate()
        {
            if (!InUse) return false;

            _framesLeft--;
            _x += _xVel;
            _y += _yVel;

            return _framesLeft == 0;
        }

        public bool InUse { get { return _framesLeft > 0; } }

        public Particle Next { get; set; } = null;
    }
}
