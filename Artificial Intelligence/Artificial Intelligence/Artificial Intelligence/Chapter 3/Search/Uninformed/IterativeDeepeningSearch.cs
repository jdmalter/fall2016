using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Collections;
using Artificial_Intelligence.Chapter_3.Search.Uninformed.DepthLimitedSearch;
using Artificial_Intelligence.Guard;
using System;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed iterative deepening last in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class IterativeDeepeningSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
             where TProblem : IProblem<TState, TAction>
             where TState : IState
             where TAction : IAction
    {
        /// <summary>
        /// An uninformed depth limited last in first out queue search.
        /// </summary>
        private DepthLimitedSearch<TProblem, TState, TAction> _depthLimitedSearch;

        /// <summary>
        /// A depth at which node has no successors.
        /// </summary>
        private readonly int _limit;

        /// <summary>
        /// Specifies a depth limited search and a limit.
        /// </summary>
        /// <param name="depthLimitedSearch">An uninformed depth limited last in first out queue search.</param>
        /// <param name="limit">A depth at which node has no successors.</param>
        public IterativeDeepeningSearch(DepthLimitedSearch<TProblem, TState, TAction> depthLimitedSearch, int limit)
        {
            _depthLimitedSearch = depthLimitedSearch.NonNull();
            _limit = limit;

            if (_depthLimitedSearch.Limit != 0)
            {
                throw new ArgumentException("depth limited search's limit must be zero");
            }
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal or an empty sequence.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            for (int limit = 0; limit <= _limit; limit++, _depthLimitedSearch = _depthLimitedSearch.Deepen())
            {
                IList<TAction> actions = _depthLimitedSearch.Search(problem);
                if (!actions.IsEmpty())
                {
                    return actions;
                }
            }

            return new List<TAction>();
        }
    }
}
