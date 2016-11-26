using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Search;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Problem
{
    /// <summary>
    /// A problem solving agent program that searches for actions and ignores percepts.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TAgentState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class SearchProblemSolvingAgentProgram<TProblem, TState, TAction>
        : SimpleProblemSolvingAgentProgram<IPercept, TProblem, TState, TAction>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A functional interface for search.
        /// </summary>
        private ISearch<TProblem, TState, TAction> _search;

        /// <summary>
        /// Specifies the agent's current conception of the world state,
        /// a singular goal state, and a functional interface for search.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="goal">A singular goal state.</param>
        /// <param name="search">A functional interface for search.</param>
        public SearchProblemSolvingAgentProgram(TState state, TAction action, ISearch<TProblem, TState, TAction> search)
            : base(state, action)
        {
            _search = search.NonNull();
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public override IList<TAction> Search(TProblem problem)
        {
            return _search.Search(problem);
        }

        /// <summary>
        /// Some implementations ignore any percepts.
        /// Returns the agent's updated conception of the world state.
        /// </summary>
        /// <param name="state">The agent's current conception of the world state.</param>
        /// <param name="percept">An agent's input at any given instant.</param>
        /// <returns>The agent's updated conception of the world state.</returns>
        public override TState UpdateState(TState state, IPercept percept)
        {
            return state;
        }
    }
}
