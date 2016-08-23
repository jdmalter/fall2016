namespace Game_Programming_Patterns.Flyweight
{
    public class Terrain
    {
        public Terrain(int movementCost, bool isWater, Texture texture)
        {
            MovementCost = movementCost;
            IsWater = isWater;
            Texture = texture;
        }

        public int MovementCost { get; private set; }

        public bool IsWater { get; private set; }

        public Texture Texture { get; private set; }
    }
}
