namespace Game_Programming_Patterns.Component
{
    public class BjornPhysicsComponent : PhysicsComponent
    {
        public void Update(GameObject bjorn, World world)
        {
            bjorn.X += bjorn.Velocity;
            world.ResolveCollision(bjorn.X, bjorn.Y, bjorn.Velocity);
        }
    }
}
