namespace Game_Programming_Patterns.State
{
    public abstract class OnGroundState : HeroineState
    {
        public abstract void Enter(Heroine heroine);

        public HeroineState HandleInput(Heroine heroine, Input input)
        {
            if (input == Input.PRESS_B)
            {
                return null; // JUMP
            }
            else if (input == Input.PRESS_DOWN)
            {
                return null; // DUCK
            }
            else
            {
                return null;
            }
        }

        public abstract void Update(Heroine heroine);
    }
}
