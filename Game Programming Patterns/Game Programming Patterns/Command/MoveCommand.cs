namespace Game_Programming_Patterns.Command
{
    public class MoveCommand : ICommandUnit
    {
        private IUnit Unit { get; set; }

        private int X { get; set; }

        private int Y { get; set; }

        private int XBefore { get; set; }

        private int YBefore { get; set; }

        public MoveCommand(IUnit unit, int x, int y)
        {
            Unit = unit;
            X = x;
            Y = y;
        }

        public void Execute()
        {
            XBefore = Unit.X;
            YBefore = Unit.Y;
            Unit.MoveTo(X, Y);
        }

        public void Undo()
        {
            Unit.MoveTo(XBefore, YBefore);
        }
    }
}
