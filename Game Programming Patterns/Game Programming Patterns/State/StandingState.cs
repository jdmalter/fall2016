namespace Game_Programming_Patterns.State
{
    public class StandingState : OnGroundState
    {
        public override void Enter(Heroine heroine)
        {
        }

        public new HeroineState HandleInput(Heroine heroine, Input input)
        {
            if (input == Input.PRESS_DOWN)
            {
                return new DuckingState();
            }
            else
            {
                return base.HandleInput(heroine, input);
            }
        }

        public override void Update(Heroine heroine)
        {
        }
    }
}
