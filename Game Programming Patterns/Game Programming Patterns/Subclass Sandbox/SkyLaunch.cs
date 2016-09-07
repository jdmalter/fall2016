namespace Game_Programming_Patterns.Subclass_Sandbox
{
    public class SkyLaunch : SuperPower
    {
        protected override void Activate()
        {
            if (Z == 0)
            {
                // On the ground, so spring into the air.
                PlaySound(0, 1.0f);
                SpawnParticles(1, 10);
                Z = 20;
            }
            else if (Z < 10.0f)
            {
                // Near the ground, so doa double jump.
                PlaySound(1, 1.0f);
                Z -= 20;
            }
            else
            {
                // Way up in the air, so do a dive attack.
                PlaySound(2, 0.7f);
                SpawnParticles(0, 1);
                Z = 0;
            }
        }
    }
}
