using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// An queens agents's actions through actuators on an environment. 
    /// </summary>
    public class QueensAction : Action
    {
        public static readonly string ADD = "Add";
        public static readonly string REMOVE = "Remove";

        /// <summary>
        /// Specifies the string representation, the x dimension coordinate, and the x dimension coordinate.
        /// </summary>
        /// <param name="name">The string representation.</param>
        /// <param name="x">The x dimension coordinate.</param>
        /// <param name="y">The y dimension coordinate.</param>
        private QueensAction(string name, uint x, uint y) : base(name)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// The x dimension coordinate.
        /// </summary>
        public uint X { get; }

        /// <summary>
        /// The y dimension coordinate.
        /// </summary>
        public uint Y { get; }

        /// <summary>
        /// Specifies the x dimension coordinate and the x dimension coordinate.
        /// </summary>
        /// <param name="x">The x dimension coordinate.</param>
        /// <param name="y">The y dimension coordinate.</param>
        /// <returns>New ADD action.</returns>
        public static QueensAction Add(uint x, uint y)
        {
            return new QueensAction(ADD, x, y);
        }

        /// <summary>
        /// Specifies the x dimension coordinate and the x dimension coordinate.
        /// </summary>
        /// <param name="x">The x dimension coordinate.</param>
        /// <param name="y">The y dimension coordinate.</param>
        /// <returns>New REMOVE action.</returns>
        public static QueensAction Remove(uint x, uint y)
        {
            return new QueensAction(REMOVE, x, y);
        }
    }
}
