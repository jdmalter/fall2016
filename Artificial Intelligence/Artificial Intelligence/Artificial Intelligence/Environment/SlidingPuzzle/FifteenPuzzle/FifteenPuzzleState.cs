using System;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.FifteenPuzzle
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class FifteenPuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// The number of elements in any dimension.
        /// </summary>
        public static readonly uint DefaultLength = 4;

        /// <summary>
        /// Specifies a square two dimensional array of values.
        /// </summary>
        /// <param name="locations">A square two dimensional array of values.</param>
        public FifteenPuzzleState(uint[,] locations) : base(DefaultLength, locations)
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">An FifteenPuzzleState being copied.</param>
        public FifteenPuzzleState(FifteenPuzzleState copy) : base(copy)
        {

        }

        /// <summary>
        /// A standard completed fifteen puzzle state.
        /// </summary>
        public static FifteenPuzzleState DefaultGoalState
        {
            get
            {
                return new FifteenPuzzleState(new uint[,]
                {
                    {  0,  1,  2,  3, },
                    {  4,  5,  6,  7, },
                    {  8,  9, 10, 11, },
                    { 12, 13, 14, 15, }
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
            return new FifteenPuzzleState(locations);
        }
    }
}
