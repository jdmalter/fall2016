namespace Game_Programming_Patterns.Component
{
    public class BjornGraphicsComponent : GraphicsComponent
    {
        private Sprite _stand;
        private Sprite _walkLeft;
        private Sprite _walkRight;

        public void Update(GameObject bjorn, Graphics graphics)
        {
            Sprite sprite = _stand;
            if (bjorn.Velocity < 0)
            {
                sprite = _walkLeft;
            } else if (bjorn.Velocity > 0)
            {
                sprite = _walkRight;
            }

            graphics.Draw(sprite, bjorn.X, bjorn.Y);
        }
    }
}
