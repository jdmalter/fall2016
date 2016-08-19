namespace Game_Programming_Patterns.Command
{
    public class InputHandler
    {
        private ICommandGameActor _buttonX;
        private ICommandGameActor _buttonY;
        private ICommandGameActor _buttonA;
        private ICommandGameActor _buttonB;

        private Button Button { get; set; }

        public ICommandGameActor HandleInput()
        {
            if (IsPressed(Button.BUTTON_X)) return _buttonX;
            if (IsPressed(Button.BUTTON_Y)) return _buttonY;
            if (IsPressed(Button.BUTTON_A)) return _buttonA;
            if (IsPressed(Button.BUTTON_B)) return _buttonB;

            // Nothing pressed, so do nothing.
            return null;
        }

        private bool IsPressed(Button button)
        {
            return Button == button;
        }
    }
}
