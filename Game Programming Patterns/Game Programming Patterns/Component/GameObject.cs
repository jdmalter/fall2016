namespace Game_Programming_Patterns.Component
{
    public class GameObject
    {
        private InputComponent _input;
        private PhysicsComponent _physics;
        private GraphicsComponent _graphics;

        public GameObject(InputComponent input, PhysicsComponent physics, GraphicsComponent graphics)
        {
            _input = input;
            _physics = physics;
            _graphics = graphics;
        }

        public void Update(World world, Graphics graphics)
        {
            _input.Update(this);
            _physics.Update(this, world);
            _graphics.Update(this, graphics);
        }

        public int Velocity { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
