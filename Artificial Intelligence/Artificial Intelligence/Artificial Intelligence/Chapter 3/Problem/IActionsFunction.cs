using Artificial_Intelligence.Chapter_2.Agent;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A functional interface for Actions.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public interface IActionsFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        ISet<TAction> Actions(TState state);
    }
}
