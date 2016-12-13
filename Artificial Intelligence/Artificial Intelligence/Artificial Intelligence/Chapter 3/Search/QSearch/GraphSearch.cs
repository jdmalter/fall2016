using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Collections;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// A queue search that stores explored nodes.
    /// </summary>
    /// <typeparam name="TQueue">Any queue of INode of TState and TAction.</typeparam>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class GraphSearch<TQueue, TProblem, TState, TAction>
        : QueueSearch<TQueue, TProblem, TState, TAction>
        where TQueue : IQueue<INode<TState, TAction>>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A data structure which remembers every expanded node.
        /// </summary>
        private readonly ISet<TState> _explored = new HashSet<TState>();

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public override IList<TAction> Search(TProblem problem, TQueue frontier)
        {
            _explored.Clear();
            return base.Search(problem, frontier);
        }

        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public override void Add(TQueue frontier, INode<TState, TAction> node)
        {
            if (!_explored.Contains(node.State))
            {
                frontier.Push(node);
            }
        }

        /// <summary>
        /// Removes every node from the frontier while the frontier is not empty and the next node has been explored.
        /// Determines whether the frontier contains any nodes available for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>Whether the frontier contains any nodes available for expansion.</returns>
        public override bool IsEmpty(TQueue frontier)
        {
            frontier.PopWhile(node => _explored.Contains(node.State));
            return frontier.IsEmpty();
        }

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A node for expansion.</returns>
        public override INode<TState, TAction> Remove(TQueue frontier)
        {
            INode<TState, TAction> node = frontier.Pop();
            _explored.Add(node.State);
            return node;
        }
    }
}
