namespace Game_Programming_Patterns.Object_Pool
{
    public class ParticlePool
    {
        private static readonly int POOL_SIZE = 100;
        private Particle[] _particles = new Particle[POOL_SIZE];
        private Particle _firstAvailable;

        public ParticlePool()
        {
            _particles[0] = new Particle();
            _firstAvailable = _particles[0];

            for (int i = 1; i < POOL_SIZE; i++)
            {
                _particles[i] = new Particle();
                _particles[i - 1].Next = _particles[i];
            }
        }

        public void Create(double x, double y, double xVel, double yVel, int lifetime)
        {
            Particle particle = _firstAvailable;
            _firstAvailable = particle.Next;
            particle.Create(x, y, xVel, yVel, lifetime);
        }

        public void Animate()
        {
            foreach (Particle particle in _particles)
            {
                if (particle.Animate())
                {
                    particle.Next = _firstAvailable;
                    _firstAvailable = particle;
                }
            }
        }
    }
}
