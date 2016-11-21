namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    ///  The abstraction for a single point in a two dimensional space. 
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Specifies x and y dimension coordinates.
        /// </summary>
        /// <param name="x">A x dimension coordinate.</param>
        /// <param name="y">A y dimension coordinate.</param>
        public Location(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// A x dimension coordinate.
        /// </summary>
        public uint X { get; }

        /// <summary>
        /// A y dimension coordinate.
        /// </summary>
        public uint Y { get; }
    }
}
