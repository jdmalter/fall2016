using Artificial_Intelligence.Guard;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_2.Agent
{
    /// <summary>
    /// A model based reflex agent.It keeps track of the current state of the world,
    /// using an internal model. It then chooses an action in the same way as the reflex agent.
    /// </summary>
    /// <typeparam name="TModel">Any model of TState, TPercept, and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class ModelReflexAgentProgram<TModel, TPercept, TRule, TState, TAction> : IAgentProgram<TPercept, TAction>
        where TModel : IModel<TState, TPercept, TAction>
        where TPercept : IPercept
        where TRule : ConditionActionRule<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// The agent's current conception of the world state.
        /// </summary>
        private TState _state;

        /// <summary>
        /// The most recent action, initially none.
        /// </summary>
        private TAction _action;

        /// <summary>
        /// A description of how the next state depends on current state and action.
        /// </summary>
        private readonly TModel _model;

        /// <summary>
        /// A set of condition action rules.
        /// </summary>
        private readonly ISet<TRule> _rules;

        /// <summary>
        /// An alternative rule if rules does not contain a matching rule.
        /// </summary>
        private readonly TRule _rule;

        /// <summary>
        /// Specifies a description of how the next state depends on current state, percept, and action,
        /// a set of condition action rules, and an alternative rule if rules does not contain a matching rule.
        /// </summary>
        /// <param name="model">A description of how the next state depends on current state and action.</param>
        /// <param name="rules">A set of condition action rules.</param>
        /// <param name="rule">An alternative rule if rules does not contain a matching rule.</param>
        public ModelReflexAgentProgram(TModel model, ISet<TRule> rules, TRule rule)
        {
            _model = model.NonNull();
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
            _state = UpdateState(_state, percept, _action, _model);
            TRule rule = RuleMatch(_state);
            _action = rule.Action;
            return _action;
        }

        /// <summary>
        /// Creates the new internal state description.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">New percept.</param>
        /// <param name="action">The most recent action.</param>
        /// <param name="model">A description of how the next state depends on current state and action.</param>
        /// <returns>The agent's updated conception of the world state.</returns>
        public abstract TState UpdateState(TState state, TPercept percept, TAction action, TModel model);

        /// <summary>
        /// Returns the first rule in the set of rules that matches the given state.
        /// Actual implementations can as simple as logic gates.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <returns>A condition action rule.</returns>
        private TRule RuleMatch(TState state)
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
