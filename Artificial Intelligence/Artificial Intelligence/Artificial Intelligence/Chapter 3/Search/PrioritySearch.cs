using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.List;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search
{
    /// <summary>
    /// A priority queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public abstract class PrioritySearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
        where TProblem : IProblem<TState, TAction>
        where TState : IState
        where TAction : IAction
    {
        /// <summary>
        /// A priority queue search that stores explored nodes.
        /// </summary>
        private readonly PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> _priorityQueueSearch;

        /// <summary>
        /// Defines a method that compares two nodes.
        /// </summary>
        private readonly IComparer<INode<TState, TAction>> _comparer;

        /// <summary>
        /// Specifies a queue search and a comparer.
        /// </summary>
        /// <param name="priorityQueueSearch">A priority queue search that stores explored nodes.</param>
        /// <param name="comparer">Defines a method that compares two nodes.</param>
        public PrioritySearch(PriorityQueueSearch<IPriorityQueue<INode<TState, TAction>>, TProblem, TState, TAction> priorityQueueSearch,
            IComparer<INode<TState, TAction>> comparer)
        {
            _priorityQueueSearch = priorityQueueSearch.NonNull();
            _comparer = comparer.NonNull();
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            IPriorityQueue<INode<TState, TAction>> frontier = new PriorityQueue<INode<TState, TAction>>(_comparer);
            return _priorityQueueSearch.Search(problem, frontier);
        }
    }
}
