namespace Game_Programming_Patterns.Command
{
    public interface ICommandGameActor
    {
        void Execute(IGameActor actor);
    }
}