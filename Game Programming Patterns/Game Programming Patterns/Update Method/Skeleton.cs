using System;

namespace Game_Programming_Patterns.Update_Method
{
    public class Skeleton : Entity
    {
        private bool _patrollingLeft = false;

        public double X { get; set; }

        public double Y { get; set; }

        public void Update()
        {
            if (_patrollingLeft)
            {
                X--;
                _patrollingLeft = X > 0 ? true : false;
            }
            else
            {
                X++;
                _patrollingLeft = X > 99 ? true : false;
            }
        }
    }
}
