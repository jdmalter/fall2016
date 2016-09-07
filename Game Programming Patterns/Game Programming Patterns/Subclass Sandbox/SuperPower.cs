namespace Game_Programming_Patterns.Subclass_Sandbox
{
    public abstract class SuperPower
    {
        protected abstract void Activate();

        protected double X { get; set; }

        protected double Y { get; set; }

        protected double Z { get; set; }

        protected void PlaySound(int sound, double volume)
        {

        }

        protected void SpawnParticles(int type, int count)
        {

        }
    }
}
