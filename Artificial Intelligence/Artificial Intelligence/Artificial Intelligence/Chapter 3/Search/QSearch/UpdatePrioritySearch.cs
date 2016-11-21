using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;
using System.Collections.Generic;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// An update priority queue search that stores explored nodes.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class UpdatePrioritySearch<TProblem, TState, TAction> : QueueSearch<IUpdatePriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction>
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
        public override IList<TAction> Search(TProblem problem, IUpdatePriorityQueue<INode<TState, TAction>> frontier)
        {
            _explored.Clear();
            return base.Search(problem, frontier);
        }

        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public override void Add(IUpdatePriorityQueue<INode<TState, TAction>> frontier, INode<TState, TAction> node)
        {
            if (!_explored.Contains(node.State) && !frontier.Push(node))
            {
                frontier.Decrease(node);
            }
        }

        /// <summary>
        /// Determines whether the frontier contains any nodes available for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>Whether the frontier contains any nodes available for expansion.</returns>
        public override bool IsEmpty(IUpdatePriorityQueue<INode<TState, TAction>> frontier)
        {
            return frontier.IsEmpty();
        }

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>A node for expansion.</returns>
        public override INode<TState, TAction> Remove(IUpdatePriorityQueue<INode<TState, TAction>> frontier)
        {
            INode<TState, TAction> node = frontier.Pop();
            _explored.Add(node.State);
            return node;
        }
    }
}
