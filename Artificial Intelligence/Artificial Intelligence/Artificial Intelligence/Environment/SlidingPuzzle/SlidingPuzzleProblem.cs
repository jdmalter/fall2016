using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.SlidingPuzzle
{
    /// <summary>
    /// An sliding puzzle problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    public class SlidingPuzzleProblem : Problem<ISlidingPuzzleState, SlidingPuzzleAction>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, and goal test.
        /// </summary>s
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalTestFunction">A functional interface for GoalTest.</param>
        public SlidingPuzzleProblem(ISlidingPuzzleState initialState,
            IActionsFunction<ISlidingPuzzleState, SlidingPuzzleAction> actionsFunction,
            IResultFunction<ISlidingPuzzleState, SlidingPuzzleAction> resultFunction,
            IGoalTestFunction<ISlidingPuzzleState> goalTestFunction)
            : base(initialState,
                  actionsFunction,
                  resultFunction,
                  goalTestFunction,
                  ConstantStepCostFunction<ISlidingPuzzleState, SlidingPuzzleAction>.ONE)
        {

        }
    }
}
