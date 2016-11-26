using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// An abstract actions function that returns a set of actions that is mapped by the given state.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class ActionsFunction<TState, TAction> : IActionsFunction<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A mapping of states to a set of actions that can be executed.
        /// </summary>
        private readonly IDictionary<TState, ISet<TAction>> _actions;

        /// <summary>
        /// Specifies a mapping of states to a set of actions that can be executed.
        /// </summary>
        /// <param name="actions">A mapping of states to a set of actions that can be executed.</param>
        public ActionsFunction(IDictionary<TState, ISet<TAction>> actions)
        {
            _actions = actions.NonNull();
        }

        /// <summary>
        /// Returns the set of actions that can be executed in the given state.
        /// </summary>
        /// <param name="state">A particular state.</param>
        /// <returns>The set of actions that can be executed in the given state.</returns>
        public ISet<TAction> Actions(TState state)
        {
            state.NonNull();

            if (_actions.ContainsKey(state))
            {
                // prevent modifications to _actions
                return new HashSet<TAction>(_actions[state]);
            }
            else
            {
                return new HashSet<TAction>();
            }
        }
    }
}
