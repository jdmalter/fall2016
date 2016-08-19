namespace Game_Programming_Patterns.Command
{
    public interface ICommandUnit
    {
        void Execute();

        void Undo();
    }
}
