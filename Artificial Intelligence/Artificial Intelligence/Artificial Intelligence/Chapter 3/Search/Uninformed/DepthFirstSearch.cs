using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;
using Artificial_Intelligence.Guard;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed last in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class DepthFirstSearch<TProblem, TState, TAction> : ISearch<TProblem, TState, TAction>
          where TProblem : IProblem<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// A search using a queue of all leaf nodes available for expansion at any given point.
        /// </summary>
        private readonly QueueSearch<ILIFOQueue<INode<TState, TAction>>, TProblem, TState, TAction> _queueSearch;

        /// <summary>
        /// Specifies a queue search.
        /// </summary>
        /// <param name="queueSearch">A search using a queue of all leaf nodes available for expansion at any given point.</param>
        public DepthFirstSearch(QueueSearch<ILIFOQueue<INode<TState, TAction>>, TProblem, TState, TAction> queueSearch)
        {
            _queueSearch = queueSearch.NonNull();
        }

        /// <summary>
        /// Returns a sequence of actions that reaches the goal.
        /// </summary>
        /// <param name="problem">A problem.</param>
        /// <returns>A sequence of actions that reaches the goal.</returns>
        public IList<TAction> Search(TProblem problem)
        {
            ILIFOQueue<INode<TState, TAction>> frontier = new LIFOQueue<INode<TState, TAction>>();
            return _queueSearch.Search(problem, frontier);
        }
    }
}
