namespace Game_Programming_Patterns.Component
{
    public static class Controller
    {
        public static Direction GetJoystickDirection()
        {
            return true ? Direction.LEFT : Direction.RIGHT;
        }
    }
}
