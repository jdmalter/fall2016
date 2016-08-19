namespace Game_Programming_Patterns.Command
{
    public interface IUnit
    {
        int X { get; set; }

        int Y { get; set; }

        void MoveTo(int x, int y);
    }
}
