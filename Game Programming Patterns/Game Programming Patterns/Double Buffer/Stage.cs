namespace Game_Programming_Patterns.Double_Buffer
{
    public class Stage
    {
        private static readonly uint NUM_ACTORS = 3;

        public Actor[] Actors { private get; set; } = new Actor[NUM_ACTORS];

        public void Update()
        {
            foreach (Actor actor in Actors)
            {
                actor.Update();
            }
            foreach (Actor actor in Actors)
            {
                actor.Swap();
            }
        }
    }
}
