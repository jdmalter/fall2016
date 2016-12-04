using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed.DepthLimitedSearch
{
    /// <summary>
    /// An uninformed depth limited last in first out queue search that stores explored nodes.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class DepthLimitedGraphSearch<TProblem, TState, TAction> : DepthLimitedSearch<TProblem, TState, TAction>
            where TProblem : IProblem<TState, TAction>
            where TState : IState
            where TAction : IAction
    {
        /// <summary>
        /// A data structure which remembers every expanded node.
        /// </summary>
        private readonly ISet<TState> _explored = new HashSet<TState>();

        /// <summary>
        /// Specifies depth at which nodes have no successors.
        /// </summary>
        /// <param name="limit">A depth at which nodes have no successors.</param>
        public DepthLimitedGraphSearch(int limit) : base(limit)
        {

        }

        /// <summary>
        /// Returns a new instance of depth limited search whose deep limit is increased by one.
        /// </summary>
        /// <returns>A new instance of depth limited search whose deep limit is increased by one.</returns>
        public override DepthLimitedSearch<TProblem, TState, TAction> Deepen()
        {
            return new DepthLimitedGraphSearch<TProblem, TState, TAction>(Limit + 1);
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal or an empty sequence.</returns>
        public override IList<TAction> Search(TProblem problem)
        {
            _explored.Clear();
            return base.Search(problem);
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <param name="node">A node.</param>
        /// <param name="limit">A depth at which nodes have no successors.</param>
        /// <returns>A sequence of actions that reaches the goal or an empty sequence.</returns>
        protected override IList<TAction> RecursiveDLS(TProblem problem, INode<TState, TAction> node, int limit)
        {
            if (_explored.Contains(node.State))
            {
                return new List<TAction>();
            }
            else
            {
                _explored.Add(node.State);
                return base.RecursiveDLS(problem, node, limit);
            }
        }
    }
}
