using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Collections;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// A queue search that stores no nodes.
    /// </summary>
    /// <typeparam name="TQueue">Any queue of INode of TState and TAction.</typeparam>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class TreeSearch<TQueue, TProblem, TState, TAction>
        : QueueSearch<TQueue, TProblem, TState, TAction>
        where TQueue : IQueue<INode<TState, TAction>>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public override void Add(TQueue frontier, INode<TState, TAction> node)
        {
            frontier.Push(node);
        }

        /// <summary>
        /// Determines whether the frontier contains any nodes available for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <returns>Whether the frontier contains any nodes available for expansion.</returns>
        public override bool IsEmpty(TQueue frontier)
        {
            return frontier.IsEmpty();
        }

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        public override INode<TState, TAction> Remove(TQueue frontier)
        {
            return frontier.Pop();
        }
    }
}
