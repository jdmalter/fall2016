namespace Game_Programming_Patterns.Component
{
    public static class Bjorn
    {
        public static GameObject CreateBjorn()
        {
            return new GameObject(new PlayerInputComponent(), new BjornPhysicsComponent(), new BjornGraphicsComponent());
        }

        public static GameObject CreateDemoBjorn()
        {
            return new GameObject(new DemoInputComponent(), new BjornPhysicsComponent(), new BjornGraphicsComponent());
        }
    }
}
