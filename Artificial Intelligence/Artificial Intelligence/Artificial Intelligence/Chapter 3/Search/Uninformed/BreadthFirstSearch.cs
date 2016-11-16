using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed first in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class BreadthFirstSearch<TProblem, TState, TAction> : UninformedQueueSearch<TProblem, TState, TAction>
         where TProblem : IProblem<TState, TAction>
         where TState : IState
         where TAction : IAction
    {
        /// <summary>
        /// Specifies a queue search.
        /// </summary>
        /// <param name="queueSearch">A search using a queue of all leaf nodes available for expansion at any given point.</param>
        public BreadthFirstSearch(QueueSearch<TProblem, TState, TAction> queueSearch)
            : base(queueSearch, new FIFOQueue<INode<TState, TAction>>())
        {

        }
    }
}
