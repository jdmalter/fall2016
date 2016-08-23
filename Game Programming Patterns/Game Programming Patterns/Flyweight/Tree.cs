using System;

namespace Game_Programming_Patterns.Flyweight
{
    public class Tree
    {
        public TreeModel Model { get; set; }
        public Tuple<int,int> Position { get; set; }
        public double Height { get; set; }
        public double Thickness { get; set; }
        public Color BarkTint { get; set; }
        public Color LeafTint { get; set; }
    }
}
