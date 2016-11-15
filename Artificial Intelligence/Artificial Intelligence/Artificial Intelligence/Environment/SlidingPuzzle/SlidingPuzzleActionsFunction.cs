using System.Collections.Generic;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// A sliding puzzle actions function that returns a combination of up, down, left, or right.
    /// </summary>
    /// <typeparam name="TSlidingPuzzleState">Any state of SlidingPuzzleState.</typeparam>
    public class SlidingPuzzleActionsFunction<TSlidingPuzzleState> : IActionsFunction<TSlidingPuzzleState, SlidingPuzzleAction>
         where TSlidingPuzzleState : SlidingPuzzleState
    {
        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular agent state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        public ISet<SlidingPuzzleAction> Actions(TSlidingPuzzleState state)
        {
            state.NonNull();
            ISet<SlidingPuzzleAction> actions = new HashSet<SlidingPuzzleAction>();

            if (state.CanMoveBlankSpaceUp())
            {
                actions.Add(SlidingPuzzleAction.UP);
            }
            if (state.CanMoveBlankSpaceDown())
            {
                actions.Add(SlidingPuzzleAction.DOWN);
            }
            if (state.CanMoveBlankSpaceLeft())
            {
                actions.Add(SlidingPuzzleAction.LEFT);
            }
            if (state.CanMoveBlankSpaceRight())
            {
                actions.Add(SlidingPuzzleAction.RIGHT);
            }

            return actions;
        }
    }
}
