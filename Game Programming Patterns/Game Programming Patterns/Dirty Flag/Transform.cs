namespace Game_Programming_Patterns.Dirty_Flag
{
    public class Transform
    {
        public static Transform Origin()
        {
            return new Transform();
        }

        public Transform Combine(Transform other)
        {
            return other;
        }
    }
}
