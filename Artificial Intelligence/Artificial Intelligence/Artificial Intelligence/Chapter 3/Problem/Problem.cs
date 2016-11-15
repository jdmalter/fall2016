using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// An abstract problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class Problem<TState, TAction> : IProblem<TState, TAction>
         where TState : IState
         where TAction : IAction
    {
        /// <summary>
        /// Specifies initial state, actions, transition model, goal test, and path cost.
        /// </summary>
        /// <param name="initialState">The initial state that the agent starts in.</param>
        /// <param name="actionsFunction">A functional interface for Actions.</param>
        /// <param name="resultFunction">A functional interface for Result.</param>
        /// <param name="goalTestFunction">A functional interface for GoalTest.</param>
        /// <param name="stepCostFunction">A functional interface for StepCost.</param>
        public Problem(TState initialState,
            IActionsFunction<TState, TAction> actionsFunction,
            IResultFunction<TState, TAction> resultFunction,
            IGoalTestFunction<TState> goalTestFunction,
            IStepCostFunction<TState, TAction> stepCostFunction)
        {
            InitialState = initialState.NonNull();
            ActionsFunction = actionsFunction.NonNull();
            ResultFunction = resultFunction.NonNull();
            GoalTestFunction = goalTestFunction.NonNull();
            StepCostFunction = stepCostFunction.NonNull();
        }

        /// <summary>
        /// The initial state that the agent starts in.
        /// </summary>
        public TState InitialState { get; }

        /// <summary>
        /// A functional interface for Actions.
        /// </summary>
        public IActionsFunction<TState, TAction> ActionsFunction { get; }

        /// <summary>
        /// A functional interface for Result.
        /// </summary>
        public IResultFunction<TState, TAction> ResultFunction { get; }

        /// <summary>
        /// A functional interface for GoalTest.
        /// </summary>
        public IGoalTestFunction<TState> GoalTestFunction { get; }

        /// <summary>
        /// A functional interface for StepCost.
        /// </summary>
        public IStepCostFunction<TState, TAction> StepCostFunction { get; }
    }
}
