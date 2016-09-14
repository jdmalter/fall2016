namespace Game_Programming_Patterns.Spatial_Partition
{
    public class Unit
    {
        private Grid _grid;
        internal double _x, _y;
        internal Unit _prev, _next;

        public Unit(Grid grid, double x, double y)
        {
            _grid = grid;
            _x = x;
            _y = y;
            _prev = null;
            _next = null;
            _grid.Add(this);
        }

        public void Move(double x, double y)
        {
            _grid.Move(this, x, y);
        }
    }
}
