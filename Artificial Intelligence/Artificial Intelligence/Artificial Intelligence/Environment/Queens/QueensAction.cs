using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// An queens agents's actions through actuators on an environment. 
    /// </summary>
    public class QueensAction : Action
    {
        public static readonly QueensAction NULL = new QueensAction("Null", 0, 0);

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
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            QueensAction action = obj as QueensAction;

            return base.Equals(action) && X == action.X && Y == action.Y;
        }

        /// <summary>
        /// Uses hash function of the string representation. 
        /// </summary>
        /// <returns>A hash code for the string representation.</returns>
        public override int GetHashCode()
        {
            int hashCode = base.GetHashCode();

            hashCode = (75936 * hashCode) + (int)X;
            hashCode = (75936 * hashCode) + (int)Y;

            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + "( " + X + ", " + Y + " )";
        }

        /// <summary>
        /// Specifies the x dimension coordinate and the x dimension coordinate.
        /// </summary>
        /// <param name="x">The x dimension coordinate.</param>
        /// <param name="y">The y dimension coordinate.</param>
        /// <returns>New ADD action.</returns>
        public static QueensAction Add(uint x, uint y)
        {
            return new QueensAction("Add", x, y);
        }
    }
}
