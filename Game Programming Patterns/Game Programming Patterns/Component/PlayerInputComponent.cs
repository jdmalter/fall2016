namespace Game_Programming_Patterns.Component
{
    public class PlayerInputComponent : InputComponent
    {
        private static readonly int WALK_ACCELERATION = 1;

        public void Update(GameObject bjorn)
        {
            switch (Controller.GetJoystickDirection())
            {
                case Direction.LEFT:
                    bjorn.Velocity -= WALK_ACCELERATION;
                    break;

                case Direction.RIGHT:
                    bjorn.Velocity += WALK_ACCELERATION;
                    break;
            }
        }
    }
}
