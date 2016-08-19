namespace Game_Programming_Patterns.Command
{
    public class FireCommand : ICommandGameActor
    {
        public void Execute(IGameActor actor)
        {
            actor.FireGun();
        }
    }
}
