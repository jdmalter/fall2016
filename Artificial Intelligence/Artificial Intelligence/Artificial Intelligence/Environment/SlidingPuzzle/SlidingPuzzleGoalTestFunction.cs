using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// A sliding puzzle goal test function that returns whether the given state equals a singular goal state.
    /// </summary>    
    public class SlidingPuzzleGoalTestFunction : GoalTestFunction<ISlidingPuzzleState>
    {
        /// <summary>
        /// Specifies a singular goal state.
        /// </summary>
        /// <param name="goal">A singular goal state.</param>
        public SlidingPuzzleGoalTestFunction(ISlidingPuzzleState goal) : base(goal)
        {

        }
    }
}
