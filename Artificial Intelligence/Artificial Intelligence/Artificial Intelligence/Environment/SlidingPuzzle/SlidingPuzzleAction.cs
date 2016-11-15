using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// A sliding puzzle agents's actions through actuators on an environment. 
    /// </summary>
    public class SlidingPuzzleAction : Action
    {
        public static readonly SlidingPuzzleAction UP = new SlidingPuzzleAction("Up");
        public static readonly SlidingPuzzleAction DOWN = new SlidingPuzzleAction("Down");
        public static readonly SlidingPuzzleAction LEFT = new SlidingPuzzleAction("Left");
        public static readonly SlidingPuzzleAction RIGHT = new SlidingPuzzleAction("Right");

        /// <summary>
        /// Specifies the string representation.
        /// </summary>
        /// <param name="name">The string representation.</param>
        private SlidingPuzzleAction(string name) : base(name)
        {

        }
    }
}
