using Artificial_Intelligence.Guard;
using System;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// An established connection between a condition and an action.
    /// </summary>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class ConditionActionRule<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Specifies a condition and action.
        /// </summary>
        /// <param name="condition">A method that defines whether or not a particular state meets the criteria
        /// to invoke an action.</param>
        /// <param name="action">An action whose criteria should be met before acting upon the environment.</param>
        public ConditionActionRule(Predicate<TState> condition, TAction action)
        {
            Condition = condition.NonNull();
            Action = action.NonNull();
        }

        /// <summary>
        /// A method that defines whether or not a particular state meets the criteria
        /// to invoke an action.
        /// </summary>
        public Predicate<TState> Condition { get; }

        /// <summary>
        /// An action whose criteria should be met before acting upon the environment.
        /// </summary>
        public TAction Action { get; }
    }
}
