using Artificial_Intelligence.Guard;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// A simple reflex agent. It acts according to a rule whose condition matches the current state,
    /// as defined by the current percept.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TRule">Any rule of TAgentState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class SimpleReflexAgentProgram<TPercept, TRule, TState, TAction> : IAgentProgram<TPercept, TAction>
        where TPercept : IPercept
        where TRule : ConditionActionRule<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A set of condition action rules.
        /// </summary>
        private readonly ISet<TRule> _rules;

        /// <summary>
        /// An alternative rule if rules does not contain a matching rule.
        /// </summary>
        private readonly TRule _rule;

        /// <summary>
        /// Specifies a set of condition action rules.
        /// </summary>
        /// <param name="rules">A set of condition action rules.</param>
        /// <param name="rule">An alternative rule if rules does not contain a matching rule.</param>
        public SimpleReflexAgentProgram(ISet<TRule> rules, TRule rule)
        {
            _rules = rules.NonNull();
            _rule = rule.NonNull();
        }

        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public TAction Invoke(TPercept percept)
        {
            TState state = InterpretInput(percept.NonNull());
            TRule rule = RuleMatch(state);
            TAction action = rule.Action;
            return action;
        }

        /// <summary>
        /// Generates an agent state from the percept.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An agent state.</returns>
        public abstract TState InterpretInput(TPercept percept);

        /// <summary>
        /// Returns the first rule in the set of rules that matches the given state.
        /// Actual implementations can as simple as logic gates.
        /// </summary>
        /// <param name="state">An agent state.</param>
        /// <returns>A condition action rule.</returns>
        public TRule RuleMatch(TState state)
        {
            foreach (TRule rule in _rules)
            {
                if (rule.Condition(state))
                {
                    return rule;
                }
            }
            return _rule;
        }
    }
}
