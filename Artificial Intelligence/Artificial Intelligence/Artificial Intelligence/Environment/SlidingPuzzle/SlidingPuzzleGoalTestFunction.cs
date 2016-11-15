using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// A sliding puzzle goal test function that returns whether the given state equals a singular goal state.
    /// </summary>    
    /// <typeparam name="TState">Any state.</typeparam>
    public class SlidingPuzzleGoalTestFunction<TSlidingPuzzleState> : GoalTestFunction<TSlidingPuzzleState>
         where TSlidingPuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// Specifies a singular goal state.
        /// </summary>
        /// <param name="state">A singular goal test.</param>
        public SlidingPuzzleGoalTestFunction(TSlidingPuzzleState state) : base(state)
        {

        }
    }
}
