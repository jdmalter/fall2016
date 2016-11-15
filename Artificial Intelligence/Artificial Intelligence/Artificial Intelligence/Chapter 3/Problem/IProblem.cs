using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A problem can be defined by five components:
    /// initial state, actions, transition model, goal test, and path cost.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// The initial state that the agent starts in.
        /// </summary>
        TState InitialState { get; }

        /// <summary>
        /// A functional interface for Actions.
        /// </summary>
        IActionsFunction<TState, TAction> ActionsFunction { get; }

        /// <summary>
        /// A functional interface for Result.
        /// </summary>
        IResultFunction<TState, TAction> ResultFunction { get; }

        /// <summary>
        /// A functional interface for GoalTest.
        /// </summary>
        IGoalTestFunction<TState> GoalTestFunction { get; }

        /// <summary>
        /// A functional interface for StepCost.
        /// </summary>
        IStepCostFunction<TState, TAction> StepCostFunction { get; }
    }
}
