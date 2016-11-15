namespace Artificial_Intelligence.Environment.SlidingPuzzle.EightPuzzle
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class EightPuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        private static readonly uint _length = 3;

        /// <summary>
        /// Specifies a square two dimensional array of values.
        /// </summary>
        /// <param name="locations">A square two dimensional array of values.</param>
        public EightPuzzleState(uint[,] locations) : base(_length, locations)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An EightPuzzleState being copied.</param>
        public EightPuzzleState(EightPuzzleState copy) : base(copy)
        {

        }
    }
}
