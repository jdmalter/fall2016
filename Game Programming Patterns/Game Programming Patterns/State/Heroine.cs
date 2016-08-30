namespace Game_Programming_Patterns.State
{
    public class Heroine
    {
        private HeroineState _state;
        private HeroineState _equipment;

        public void HandleInput(Input input)
        {
            HeroineState state = _state.HandleInput(this, input);
            HeroineState equipment = _equipment.HandleInput(this, input);
            if (state != null)
            {
                _state = state;
                _state.Enter(this);
            }
            if (equipment != null)
            {
                _equipment = equipment;
                _equipment.Enter(this);
            }
        }

        public void Update()
        {
            _state.Update(this);
        }

        public void superBomb()
        {
            // Do stuff
        }
    }
}
