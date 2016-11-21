using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// A functional interface for Result.
    /// </summary>
    public class SlidingPuzzleResultFunction : IResultFunction<ISlidingPuzzleState, SlidingPuzzleAction>
    {
        /// <summary>
        /// Returns the state that results from doing the given action in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <param name="action">An action being executed in a particular state.</param>
        /// <returns>The state that results from doing the given action in the given state.</returns>
        public ISlidingPuzzleState Result(ISlidingPuzzleState state, SlidingPuzzleAction action)
        {
            state.NonNull();
            action.NonNull();

            if (SlidingPuzzleAction.UP == action && state.CanMoveBlankSpaceUp())
            {
                return state.MoveBlankSpaceUp();
            }
            else if (SlidingPuzzleAction.DOWN == action && state.CanMoveBlankSpaceDown())
            {
                return state.MoveBlankSpaceDown();
            }
            else if (SlidingPuzzleAction.LEFT == action && state.CanMoveBlankSpaceLeft())
            {
                return state.MoveBlankSpaceLeft();
            }
            else if (SlidingPuzzleAction.RIGHT == action && state.CanMoveBlankSpaceRight())
            {
                return state.MoveBlankSpaceRight();
            }
            else
            {
                return state;
            }
        }
    }
}
