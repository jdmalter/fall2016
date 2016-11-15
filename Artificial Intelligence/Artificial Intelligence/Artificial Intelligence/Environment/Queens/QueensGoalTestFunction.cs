using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens goal test function that returns whether
    /// there are a particular number of queens on the board and none are attacked.
    /// </summary>
    /// <typeparam name="TSlidingPuzzleState">Any state of SlidingPuzzleState.</typeparam>
    public abstract class QueensGoalTestFunction<TQueenState> : IGoalTestFunction<TQueenState>
        where TQueenState : QueensState
    {
        /// <summary>
        /// The number of queens on the board.
        /// </summary>
        private readonly uint _queens;

        /// <summary>
        /// Specifies the number of queens on the board.
        /// </summary>
        /// <param name="queens">The number of queens on the board.</param>
        public QueensGoalTestFunction(uint queens)
        {
            _queens = queens;
        }

        /// <summary>
        /// Returns whether there are a particular number of queens on the board and none are attacked.
        /// </summary>
        /// <param name="state">Any state.</param>
        /// <returns>Whether there are a particular number of queens on the board and none are attacked.</returns>
        public bool GoalTest(TQueenState state)
        {
            state.NonNull();
            uint queens = 0;

            for (uint x = 0; x < state.Length; x++)
            {
                for (uint y = 0; y < state.Length; y++)
                {
                    if (state[x, y] && 0 == state.AttacksOn(x, y))
                    {
                        queens++;
                    }
                }
            }

            return _queens == queens;
        }
    }
}
