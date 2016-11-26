using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Environment.Map
{
    /// <summary>
    /// An map puzzle problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    /// <typeparam name="TState">Any map state.</typeparam>
    /// <typeparam name="TAction">Any map action of TState.</typeparam>
    public class MapProblem<TState, TAction> : Problem<TState, TAction>
        where TState : IMapState
        where TAction : MapAction<TState>
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, goal test, and path cost.
        /// </summary>
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalTestFunction">A functional interface for GoalTest.</param>
        /// <param name="stepCostFunction">A functional interface for StepCost.</param>
        public MapProblem(TState initialState,
            IActionsFunction<TState, TAction> actionsFunction,
            IResultFunction<TState, TAction> resultFunction,
            IGoalTestFunction<TState> goalTestFunction,
            IStepCostFunction<TState, TAction> stepCostFunction)
            : base(initialState, actionsFunction, resultFunction, goalTestFunction, stepCostFunction)
        {

        }
    }
}
