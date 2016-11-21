using System;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed.DepthLimitedSearch
{
    /// <summary>
    /// An uninformed depth limited last in first out queue search that stores no nodes.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class DepthLimitedTreeSearch<TProblem, TState, TAction> : DepthLimitedSearch<TProblem, TState, TAction>
            where TProblem : IProblem<TState, TAction>
            where TState : IState
            where TAction : IAction
    {
        /// <summary>
        /// Specifies a depth at which node have no successors.
        /// </summary>
        /// <param name="limit">A depth at which node have no successors.</param>
        public DepthLimitedTreeSearch(int limit) : base(limit)
        {

        }

        /// <summary>
        /// Returns a new instance of depth limited search whose deep limit is increased by one.
        /// </summary>
        /// <returns>A new instance of depth limited search whose deep limit is increased by one.</returns>
        public override DepthLimitedSearch<TProblem, TState, TAction> Deepen()
        {
            return new DepthLimitedTreeSearch<TProblem, TState, TAction>(Limit + 1);
        }
    }
}
