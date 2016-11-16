using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;

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
        /// A depth at which node have no successors.
        /// </summary>
        private readonly int _limit;

        /// <summary>
        /// Specifies a depth at which node have no successors.
        /// </summary>
        /// <param name="limit">A depth at which node have no successors.</param>
        public IterativeDeepeningSearch(int limit)
        {
            _limit = limit;
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal or an empty sequence.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            for (int limit = 0; limit < _limit; limit++)
            {
                IList<TAction> actions = new DepthLimitedSearch<TProblem, TState, TAction>(limit).Search(problem);
                if (!actions.IsEmpty())
                {
                    return actions;
                }
            }
            return new List<TAction>();
        }
    }
}
