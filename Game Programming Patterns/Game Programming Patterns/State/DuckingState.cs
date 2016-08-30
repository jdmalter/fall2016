namespace Game_Programming_Patterns.State
{
    public class DuckingState : OnGroundState
    {
        private uint _chargeTime = 0;
        private static readonly uint MaxCharge = 10;

        public override void Enter(Heroine heroine)
        {
        }

        public new HeroineState HandleInput(Heroine heroine, Input input)
        {
            if (input == Input.RELEASE_DOWN)
            {
                return new StandingState();
            }
            else
            {
                return base.HandleInput(heroine, input);
            }
        }

        public override void Update(Heroine heroine)
        {
            _chargeTime++;
            if (_chargeTime > MaxCharge)
            {
                heroine.superBomb();
            }
        }
    }
}
