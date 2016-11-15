using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// A functional interface for Result.
    /// </summary>
    /// <typeparam name="TSlidingPuzzleState">Any state of SlidingPuzzleState.</typeparam>
    public class SlidingPuzzleResultFunction<TSlidingPuzzleState> : IResultFunction<TSlidingPuzzleState, SlidingPuzzleAction>
        where TSlidingPuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// Returns the state that results from doing the given action in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <param name="action">An action being executed in a particular state.</param>
        /// <returns>The state that results from doing the given action in the given state.</returns>
        public TSlidingPuzzleState Result(TSlidingPuzzleState state, SlidingPuzzleAction action)
        {
            state.NonNull();

            if (SlidingPuzzleAction.UP == action && state.CanMoveBlankSpaceUp())
            {
                state.MoveBlankSpaceUp();
            }
            else if (SlidingPuzzleAction.DOWN == action && state.CanMoveBlankSpaceDown())
            {
                state.MoveBlankSpaceDown();
            }
            else if (SlidingPuzzleAction.LEFT == action && state.CanMoveBlankSpaceLeft())
            {
                state.MoveBlankSpaceLeft();
            }
            else if (SlidingPuzzleAction.RIGHT == action && state.CanMoveBlankSpaceRight())
            {
                state.MoveBlankSpaceRight();
            }

            return state;
        }
    }
}
