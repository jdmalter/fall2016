using System;

namespace Game_Programming_Patterns.Double_Buffer
{
    public class Comedian : Actor
    {
        public Actor facing { private get; set; }
        public bool Slapped { get; set; } = false;

        public void Update()
        {
            if (Slapped) facing.Slapped = true;
        }
    }
}
