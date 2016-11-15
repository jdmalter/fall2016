using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.Queens
{
    /// <summary>
    /// A queens problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    public class QueensProblem : Problem<QueensState, QueensAction>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, and goal test.
        /// </summary>
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalTestFunction">A functional interface for GoalTest.</param>
        public QueensProblem(QueensState initialState,
            IActionsFunction<QueensState, QueensAction> actionsFunction,
            IResultFunction<QueensState, QueensAction> resultFunction,
            IGoalTestFunction<QueensState> goalTestFunction)
            : base(initialState,
                  actionsFunction,
                  resultFunction,
                  goalTestFunction,
                  ConstantStepCostFunction<QueensState, QueensAction>.ZERO)
        {

        }
    }
}
