namespace Game_Programming_Patterns.Dirty_Flag
{
    public class GraphNode
    {
        private static readonly int MAX_CHILDREN;

        private Transform _world;
        private bool _dirty = true;
        private Transform _local = Transform.Origin();
        private GraphNode[] _children = new GraphNode[MAX_CHILDREN];
        private int _numChildren;

        public void SetTransform(Transform local)
        {
            _local = local;
            _dirty = true;
        }

        public void Render(Transform parentWorld, bool dirty)
        {
            dirty |= _dirty;
            if (dirty)
            {
                _world = _local.Combine(parentWorld);
                dirty = false;
            }

            foreach (GraphNode child in _children)
            {
                child.Render(_world, dirty);
            }
        }
    }
}
