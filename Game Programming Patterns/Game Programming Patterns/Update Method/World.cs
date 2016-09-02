using System.Collections.Generic;

namespace Game_Programming_Patterns.Update_Method
{
    public class World
    {
        private ICollection<Entity> _entities;

        void GameLoop()
        {
            while (true)
            {
                // Handle user input...

                // Update each entity.
                foreach (Entity entity in _entities)
                {
                    entity.Update();
                }

                // Physics and rendering...
            }
        }
    }
}
