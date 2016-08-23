using System;

namespace Game_Programming_Patterns.Flyweight
{
    public class World
    {

        public Terrain GrassTerrain { get; private set; } = new Terrain(1, false, new Texture());

        public Terrain HillTerrain { get; private set; } = new Terrain(3, false, new Texture());

        public Terrain RiverTerrain { get; private set; } = new Terrain(2, true, new Texture());

        public Terrain[][] Tiles { get; set; }

        private void GenerateTerrain()
        {
            int width = 5;
            int height = 5;
            // Fill the ground with grass.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tiles[x][y] = new Random().Next(10) == 0 ? HillTerrain : GrassTerrain;
                }
            }

            // Layer a river.
            int x = new Random().Next(width);
            for (int y = 0; y < height; y++)
            {
                Tiles[x][y] = RiverTerrain;
            }
        }
    }
}
