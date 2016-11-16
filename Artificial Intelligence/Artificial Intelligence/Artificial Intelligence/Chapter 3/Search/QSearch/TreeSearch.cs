using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.QSearch
{
    /// <summary>
    /// A queue search that stores no nodes.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class TreeSearch<TProblem, TState, TAction> : QueueSearch<TProblem, TState, TAction>
         where TProblem : IProblem<TState, TAction>
         where TState : IState
         where TAction : IAction
    {
        /// <summary>
        /// Adds a new leaf node available for expansion to the frontier.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        /// <param name="node">A new leaf node available for expansion.</param>
        public override void Add(IQueue<INode<TState, TAction>> frontier, INode<TState, TAction> node)
        {
            frontier.Push(node);
        }

        /// <summary>
        /// Removes and returns a node for expansion.
        /// </summary>
        /// <param name="frontier">A queue of all leaf nodes available for expansion at any given point.</param>
        public override INode<TState, TAction> Remove(IQueue<INode<TState, TAction>> frontier)
        {
            return frontier.Pop();
        }
    }
}
