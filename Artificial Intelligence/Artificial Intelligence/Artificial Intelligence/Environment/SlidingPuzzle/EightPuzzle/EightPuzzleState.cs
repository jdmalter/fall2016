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
        public static readonly uint DefaultLength = 3;

        /// <summary>
        /// Specifies a square two dimensional array of values.
        /// </summary>
        /// <param name="locations">A square two dimensional array of values.</param>
        public EightPuzzleState(uint[,] locations) : base(DefaultLength, locations)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An EightPuzzleState being copied.</param>
        public EightPuzzleState(EightPuzzleState copy) : base(copy)
        {

        }

        /// <summary>
        /// A standard completed eight puzzle state.
        /// </summary>
        public static EightPuzzleState DefaultGoalState
        {
            get
            {
                return new EightPuzzleState(new uint[,]
                {
                    { 0, 1, 2, },
                    { 3, 4, 5, },
                    { 6, 7, 8, },
                });
            }
        }

        /// <summary>
        /// Specifies the number of elements in any dimension and a square two dimensional array of values.
        /// Returns a new instance of state.
        /// </summary>
        /// <param name="length">The number of elements in any dimension.</param>
        /// <param name="locations">A square two dimensional array of values.</param>
        /// <returns>A new instance of state.</returns>
        public override ISlidingPuzzleState Create(uint length, uint[,] locations)
        {
            return new EightPuzzleState(locations);
        }
    }
}
