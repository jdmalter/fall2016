namespace Game_Programming_Patterns.State
{
    public interface HeroineState
    {
        void Enter(Heroine heroine);
    
        HeroineState HandleInput(Heroine heroine, Input input);

        void Update(Heroine heroine);
    }
}
