namespace Game_Programming_Patterns.Command
{
    public class JumpCommand : ICommandGameActor
    {
        public void Execute(IGameActor actor)
        {
            actor.Jump();
        }
    }
}
