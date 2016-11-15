using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.SlidingPuzzle.EightPuzzle
{
    /// <summary>
    /// An eight puzzple problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    public class EightPuzzleProblem : SlidingPuzzleProblem<EightPuzzleState>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, goal test, and path cost.
        /// </summary>s
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalTestFunction">A functional interface for GoalTest.</param>
        public EightPuzzleProblem(EightPuzzleState initialState,
            IActionsFunction<EightPuzzleState, SlidingPuzzleAction> actionsFunction,
            IResultFunction<EightPuzzleState, SlidingPuzzleAction> resultFunction,
            IGoalTestFunction<EightPuzzleState> goalTestFunction)
            : base(initialState, actionsFunction, resultFunction, goalTestFunction)
        {

        }
    }
}
