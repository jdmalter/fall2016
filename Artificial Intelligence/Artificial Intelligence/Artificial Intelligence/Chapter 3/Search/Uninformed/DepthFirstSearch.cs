using System;
using System.Collections.Generic;
using Artificial_Intelligence.Chapter_2.Agent;
using Artificial_Intelligence.Chapter_3.Problem;
using Artificial_Intelligence.Chapter_3.Search.QSearch;
using Artificial_Intelligence.List;

namespace Artificial_Intelligence.Chapter_3.Search.Uninformed
{
    /// <summary>
    /// An uninformed last in first out queue search.
    /// </summary>
    /// <typeparam name="TProblem">Any problem of TState and TAction.</typeparam>
    /// <typeparam name="TState">Any state.</typeparam>
    /// <typeparam name="TAction">Any action.</typeparam>
    public class DepthFirstSearch<TProblem, TState, TAction> : UninformedQueueSearch<TProblem, TState, TAction>
          where TProblem : IProblem<TState, TAction>
          where TState : IState
          where TAction : IAction
    {
        /// <summary>
        /// Specifies a queue search.
        /// </summary>
        /// <param name="queueSearch">A search using a queue of all leaf nodes available for expansion at any given point.</param>
        public DepthFirstSearch(QueueSearch<TProblem, TState, TAction> queueSearch)
            : base(queueSearch, new LIFOQueue<INode<TState, TAction>>())
        {

        }
    }
}
