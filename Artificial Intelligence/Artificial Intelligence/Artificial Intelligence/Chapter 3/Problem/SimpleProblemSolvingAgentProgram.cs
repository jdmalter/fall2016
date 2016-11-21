using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Guard;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A problem solving agent program that implements the agent function.
    /// </summary>
    /// <typeparam name="TPercept">Any percept.</typeparam>
    /// <typeparam name="TProblem">Any problem of TAgentState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class SimpleProblemSolvingAgentProgram<TPercept, TProblem, TState, TAction>
        : IAgentProgram<TPercept, TAction>
        where TPercept : IPercept
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// An action sequence, initially empty.
        /// </summary>
        private IList<TAction> _actions = new List<TAction>();

        /// <summary>
        /// The agent's current conception of the world state.
        /// </summary>
        private TState _state;

        /// <summary>
        /// An alternative action if search yields no actions.
        /// </summary>
        private readonly TAction _action;

        /// <summary>
        /// Specifies a state and an action.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="action">An alternative action if search yields no actions.</param>
        public SimpleProblemSolvingAgentProgram(TState state, TAction action)
        {
            _state = state.NonNull();
            _action = action.NonNull();
        }

        /// <summary>
        /// Maps percepts to actions.
        /// </summary>
        /// <param name="percept">New percept.</param>
        /// <returns>An action.</returns>
        public TAction Invoke(TPercept percept)
        {
            _state = UpdateState(_state, percept);
            if (_actions.IsEmpty())
            {
                TState goal = FormulateGoal(_state);
                TProblem problem = FormulateProblem(_state, goal);
                _actions = Search(problem);
                if (_actions.IsEmpty())
                {
                    return _action;
                }
            }
            TAction action = _actions.First();
            _actions.Rest();
            return action;
        }

        /// <summary>
        /// Returns a possible goal state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <returns>A possible goal state.</returns>
        public abstract TState FormulateGoal(TState state);

        /// <summary>
        /// Specifies an initial state and a goal state. Returns a new problem.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="goal">A possible goal state.</param>
        /// <returns>A new problem.</returns>
        public abstract TProblem FormulateProblem(TState state, TState goal);

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public abstract IList<TAction> Search(TProblem problem);

        /// <summary>
        /// Some implementations ignore any percepts.
        /// Returns the agent's updated conception of the world state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">An agent's input at any given instant.</param>
        /// <returns>The agent's updated conception of the world state.</returns>
        public abstract TState UpdateState(TState state, TPercept percept);
    }
}
