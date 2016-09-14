namespace Game_Programming_Patterns.Spatial_Partition
{
    public class Grid
    {
        public static readonly int NUM_CELLS = 10;
        public static readonly int CELL_SIZE = 20;
        private Unit[,] _cells = new Unit[NUM_CELLS, NUM_CELLS];

        public void Add(Unit unit)
        {
            int cellX = (int)(unit._x / CELL_SIZE);
            int cellY = (int)(unit._y / CELL_SIZE);

            unit._prev = null;
            unit._next = _cells[cellX, cellY];
            _cells[cellX, cellY] = unit;

            if (unit._next != null)
            {
                unit._next._prev = unit;
            }
        }

        public void HandleMelee()
        {
            for (int x = 0; x < NUM_CELLS; x++)
            {
                for (int y = 0; y < NUM_CELLS; y++)
                {
                    HandleCell(x, y);
                }
            }
        }

        public void HandleCell(int x, int y)
        {
            Unit unit = _cells[x, y];
            while (unit != null)
            {
                // Handle other units in this cell.
                HandleUnit(unit, unit._next);

                // Also try the neighboring cells.
                if (x > 0 && y > 0) HandleUnit(unit, _cells[x - 1, y - 1]);
                if (x > 0) HandleUnit(unit, _cells[x - 1, y]);
                if (y > 0) HandleUnit(unit, _cells[x, y - 1]);
                if (x > 0 && y < NUM_CELLS - 1) HandleUnit(unit, _cells[x - 1, y + 1]);

                unit = unit._next;
            }
        }

        private void HandleUnit(Unit unit, Unit other)
        {
            while (other != null)
            {
                if (unit._x == other._x &&
                    unit._y == other._y)
                {
                    HandleAttack(unit, other);
                }
                other = other._next;
            }
        }

        private void HandleAttack(Unit unit, Unit other)
        {
        }

        public void Move(Unit unit, double x, double y)
        {
            // See which cell it was in.
            int oldCellX = (int)(unit._x / CELL_SIZE);
            int oldCellY = (int)(unit._y / CELL_SIZE);

            // See which cel it's moving to.
            int cellX = (int)(x / CELL_SIZE);
            int cellY = (int)(y / CELL_SIZE);

            unit._x = x;
            unit._y = y;

            // If it didn't change cells, we're done.
            if (oldCellX == cellX && oldCellY == cellY) return;

            // Unlink it form the list of its old cell.
            if (unit._prev != null)
            {
                unit._prev._next = unit._next;
            }

            if (unit._next != null)
            {
                unit._next._prev = unit._prev;
            }

            if (_cells[oldCellX, oldCellY] == unit)
            {
                _cells[oldCellX, oldCellY] = unit._next;
            }

            Add(unit);
        }
    }
}
