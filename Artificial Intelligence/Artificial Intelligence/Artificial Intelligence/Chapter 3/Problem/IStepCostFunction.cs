using Artificial_Intelligence.Chapter_2.Agent;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A functional interface for StepCost.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IStepCostFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Returns the cost of taking the given action in the initial state to reach the final state.
        /// </summary>
        /// <param name="initial">The initial state.</param>
        /// <param name="action">The taken action.</param>
        /// <param name="final">The final state.</param>
        /// <returns>The cost of taking the given action in the initial state to reach the final state.</returns>
        double StepCost(TState initial, TAction action, TState final);
    }
}
