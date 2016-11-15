namespace Artificial_Intelligence.Environment.SlidingPuzzle.NinetyNinePuzzle
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class NinetyNinePuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        private static readonly uint _length = 10;

        /// <summary>
        /// Specifies a square two dimensional array of values.
        /// </summary>
        /// <param name="locations">A square two dimensional array of values.</param>
        public NinetyNinePuzzleState(uint[,] locations) : base(_length, locations)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An NinetyNinePuzzleState being copied.</param>
        public NinetyNinePuzzleState(NinetyNinePuzzleState copy) : base(copy)
        {

        }
    }
}
